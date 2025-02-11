using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using DHPhoneStore.Models;
using DHPhoneStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace DHPhoneStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly HttpClient _httpClient;
        private const string VNPayUrl = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html"; 
        private const string MerchantId = "UWT3B96K";
        private const string SecretKey = "6WDHCZYD01U0OQBSX1R7J5ZQMQSJ80PJ";
        public UserController(IUserService service, HttpClient httpClient)
        {
            _service = service;
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var item = await _service.GetAll();
            return Ok(item);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var item = await _service.GetUserByIdAsync(id);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            var id = await _service.PostUserAsync(user);
            return Ok(new { UserID = id });

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var item = await _service.UpdateUserAsync(user);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var item = await _service.DeleteUserAsync(id);
            return Ok(item);
        }
        [HttpPost("Auth/Register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            var item = await _service.RegisterUserAsync(user);
            return Ok(item);
        }

        [HttpPost("Auth/Login")]
        public async Task<IActionResult> LoginUser([FromBody] User user)
        {
            var item = await _service.LoginUserAsync(user);
            return Ok(item);
        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCart req)
        {
            var item = await _service.AddToCartAsync(req);
            return Ok(item);
        }

        [HttpGet("Cart/{UserID}")]
        public async Task<IActionResult> Cart(int UserID)
        {
            var item = await _service.CartAsync(UserID);
            return Ok(item);
        }

        [HttpPost("FirstCheckout")]
        public async Task<IActionResult> FirstCheckout([FromBody] List<CartUser> req)
        {
            var item = await _service.FirstCheckoutAsync(req);
            return Ok(item);
        }

        [HttpPost("Checkout")]
        public async Task<IActionResult> Checkout([FromBody] UserOrder req)
        {
            var item = await _service.CheckoutAsync(req);
            return Ok(item);
        }

        [HttpGet("OrderHistory/{UserID}")]
        public async Task<IActionResult> OrderHistory(string UserID)
        {
            var item = await _service.OrderHistoryAsync(UserID);
            return Ok(item);
        }

        [HttpPost("SubmitReview")]
        public async Task<IActionResult> SubmitReview([FromBody] ReviewProduct req)
        {
            var item = await _service.SubmitReviewAsync(req);
            return Ok(item);
        }

        [HttpPost("VNPay")]
        public async Task<IActionResult> VNPay([FromBody] VNPayRequest request)
        {
            try
            {
                var vnpParams = new SortedDictionary<string, string>
                {
                    { "vnp_Version", "2.1.0" },
                    { "vnp_Command", "pay" },
                    { "vnp_TmnCode", MerchantId },
                    { "vnp_Amount", (request.TotalAmount * 100).ToString() }, 
                    { "vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss") },
                    { "vnp_CurrCode", "VND" },
                    { "vnp_IpAddr", "127.0.0.1" },
                    { "vnp_Locale", "vn" },
                    { "vnp_OrderInfo", "thanhtoan" },
                    { "vnp_OrderType", "other" },
                    { "vnp_ReturnUrl", "http://localhost:5173/payment-result" },
                    //{ "vnp_ReturnUrl", "https://dacntt2-u7sm.onrender.com/payment-result" },
                    { "vnp_ExpireDate", DateTime.Now.AddMinutes(10).ToString("yyyyMMddHHmmss") },
                    { "vnp_TxnRef", request.OrderID.ToString() + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")},
                };
                string hash = string.Join("&", vnpParams.Select(kvp => $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(kvp.Value)}"));
                string secureHash = ComputeHmacSha512(SecretKey, hash);
                var paymentUrl = VNPayUrl + "?" + hash + "&vnp_SecureHash=" + secureHash;
                return Ok(new { paymentUrl });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        private static string ComputeHmacSha512(string key, string data)
        {
            var hash = new StringBuilder();
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            using (var hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(dataBytes);
                foreach(var theByte in hashBytes)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }
            return hash.ToString();
        }
        [HttpPost("ReturnUrl")]
        public async Task<IActionResult> ReturnUrl([FromBody] Dictionary<string, string> queryParams)
        {
            // Kiểm tra mã phản hồi
            if (!queryParams.ContainsKey("vnp_ResponseCode"))
            {
                return BadRequest(new { message = "Thiếu mã phản hồi." });
            }

            // Tạo chuỗi hash để xác thực
            string secureHash = queryParams["vnp_SecureHash"];
            queryParams.Remove("vnp_SecureHash");

            string hashData = string.Join("&", queryParams
                .OrderBy(kvp => kvp.Key)
                .Select(kvp => $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(kvp.Value)}"));

            string computedHash = ComputeHmacSha512(SecretKey, hashData);

            // Kiểm tra hash
            if (secureHash != computedHash)
            {
                return BadRequest(new { message = "Xác thực thất bại." });
            }

            // Xử lý kết quả thanh toán
            var responseCode = queryParams["vnp_ResponseCode"];
            if (responseCode == "00")
            {
                var item = await _service.UpdateOrderStatus(queryParams);
                return Ok(new { message = "Thanh toán thành công." });
            }
            else
            {
                var item = await _service.UpdateOrderStatus(queryParams);
                return Ok(new { message = "Thanh toán thất bại." });
            }
        }
    }
}

