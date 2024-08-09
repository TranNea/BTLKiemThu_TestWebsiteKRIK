using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.DevTools.V122.Database;

namespace _47_Nhan_N1_DangKy
{
    //Test chức năng Đăng ký tài khoản

    [TestClass]
    public class RegisterUnitTest_47_Nhan_N1
    {
        //47_Nhan_N1
        //Test case 1 - Đăng ký tài khoản thành công
        [TestMethod]
        public void TC1_DangKyThanhCong_47_Nhan()
        {
            //Tắt màn đen
            ChromeDriverService chrome_47_Nhan = ChromeDriverService.CreateDefaultService();
            chrome_47_Nhan.HideCommandPromptWindow = true;

            //Điều hướng trình duyệt
            IWebDriver driver_47_Nhan = new ChromeDriver(chrome_47_Nhan);
            driver_47_Nhan.Navigate().GoToUrl("https://krik.vn/");

            //Lấy element của quảng cáo để tắt quảng cáo
            //Thread.Sleep(2000);
            //driver_47_Nhan.FindElement(By.ClassName("modal-dialog")).Click();

            //Lấy element của Tài khoản
            Thread.Sleep(2000);
            ////driver_47_Nhan.FindElement(By.ClassName("showcustomer")).Click();
            var element = driver_47_Nhan.FindElement(By.ClassName("showcustomer"));  // tìm phần tử muốn click
            ((IJavaScriptExecutor)driver_47_Nhan).ExecuteScript("arguments[0].click();", element);

            //Lấy element của Đăng ký
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.XPath("//*[@id=\"root\"]/main/div/div/a[@href='/user/signup']")).Click();

            //Lấy element các trường thông tin để điền dữ liệu
            //Lấy element của trường Họ tên
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.Id("fullName")).SendKeys("Tran Le Hoai Nhan");

            //Lấy element của trường Điện thoại
            Thread.Sleep(1000);
            driver_47_Nhan.FindElement(By.Name("mobile")).SendKeys("0854821565");

            //Lấy element của trường Email
            Thread.Sleep(1000);
            driver_47_Nhan.FindElement(By.CssSelector("input[type='email']")).SendKeys("2151050296nhan@ou.edu.vn");

            //Lấy element của trường Mật khẩu
            Thread.Sleep(1000);
            driver_47_Nhan.FindElement(By.CssSelector("input[type='password']")).SendKeys("Nhan47");

            //Lấy element của nút Đăng ký
            Thread.Sleep(200);
            driver_47_Nhan.FindElement(By.Id("btnsingup")).Click();

            //Tắt trình duyệt test
            driver_47_Nhan.Quit();
        }


        //47_Nhan_N1
        //Test case 2 - Đăng ký tài khoản không thành công
        /*
         * Test case 2.1 - Đăng ký tài khoản cùng email nhưng khác mật khẩu
         * Test case 2.2 - Đăng ký tài khoản cùng số điện thoại nhưng khác email
         * Test case 2.3 - Đăng ký tài khoản với email phần local part có kí tự đặc biệt
         * Test case 2.4 - Đăng ký tài khoản với email phần domain name có kí tự đặc biệt (trừ dấu chấm)
         * Test case 2.5 - Đăng ký tài khoản với email phần domain name không hợp lệ
         * Test case 2.6 - Đăng ký tài khoản với email thiếu “@” giữa local part và domain name
         * Test case 2.7 - Đăng ký tài khoản với email phần domain name có các dấu chấm kề nhau
         * Test case 2.8 - Đăng ký tài khoản với email thiếu tên miền cấp cao nhất
         * Test case 2.9 - Đăng ký tài khoản với email có dấu chấm nằm đầu local part
         * Test case 2.10 - Đăng ký tài khoản với email có dấu chấm nằm cuối local part
         * Test case 2.11 - Đăng ký tài khoản với số điện thoại sai định dạng (chữ số đầu không phải số 0)
         * Test case 2.12 - Đăng ký tài khoản với số điện thoại sai định dạng (chứa chữ,  kí tự đặc biệt)
         * Test case 2.13 - Đăng ký tài khoản với số điện thoại sai định dạng (quá 10 số)
         * Test case 2.14 - Đăng ký tài khoản mà không nhập dữ liệu
         * Test case 2.15 - Đăng ký tài khoản chỉ nhập dữ liệu vào trường Họ tên, còn lại không nhập dữ liệu
         * Test case 2.16 - Đăng ký tài khoản chỉ nhập dữ liệu vào trường Họ tên, Điện thoại, còn lại không nhập dữ liệu
         * Test case 2.17 - Đăng ký tài khoản chỉ nhập dữ liệu vào các trường trừ Mật khẩu
         */

        //Lấy dữ liệu từ file RegisterData_47_Nhan.csv
        public TestContext TestContext { get; set; }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                         @".\RegisterData\RegisterData_47_Nhan.csv", "RegisterData_47_Nhan#csv", DataAccessMethod.Sequential)]

        [TestMethod]
        public void TC2_DangKyKhongThanhCong_47_Nhan()
        {
            //Gán dữ liệu cho các trường thông tin
            var fullname = TestContext.DataRow[0].ToString(); //Họ tên
            var mobile = TestContext.DataRow[1].ToString(); //Số điện thoại
            var email = TestContext.DataRow[2].ToString(); //Email
            var password = TestContext.DataRow[3].ToString(); //Mật khẩu

            //Tắt màn đen
            ChromeDriverService chrome_47_Nhan = ChromeDriverService.CreateDefaultService();
            chrome_47_Nhan.HideCommandPromptWindow = true;

            //Điều hướng trình duyệt
            IWebDriver driver_47_Nhan = new ChromeDriver(chrome_47_Nhan);
            driver_47_Nhan.Navigate().GoToUrl("https://krik.vn/");

            Thread.Sleep(2000);
            //Lấy element của quảng cáo để tắt quảng cáo
            //driver_47_Nhan.FindElement(By.ClassName("modal-dialog")).Click();

            Thread.Sleep(2000);
            //Lấy element của Tài khoản
            //driver_47_Nhan.FindElement(By.ClassName("showcustomer")).Click();
            var element = driver_47_Nhan.FindElement(By.ClassName("showcustomer"));  // tìm phần tử muốn click
            ((IJavaScriptExecutor)driver_47_Nhan).ExecuteScript("arguments[0].click();", element);

            Thread.Sleep(2000);
            //Lấy element của Đăng ký, truy cập vào trang Đăng ký
            driver_47_Nhan.FindElement(By.XPath("//*[@id=\"root\"]/main/div/div/a[@href='/user/signup']")).Click();

            //Lấy element các trường thông tin để điền dữ liệu

            Thread.Sleep(2000);
            //Lấy element của trường Họ tên, nhập họ tên
            driver_47_Nhan.FindElement(By.Id("fullName")).SendKeys(fullname);

            Thread.Sleep(1000);
            //Lấy element của trường Điện thoại, nhập số điện thoại
            driver_47_Nhan.FindElement(By.Name("mobile")).SendKeys(mobile);

            Thread.Sleep(1000);
            //Lấy element của trường Email, nhập email
            driver_47_Nhan.FindElement(By.CssSelector("input[type='email']")).SendKeys(email);

            Thread.Sleep(1000);
            //Lấy element của trường Mật khẩu, nhập mật khẩu
            driver_47_Nhan.FindElement(By.CssSelector("input[type='password']")).SendKeys(password);

            Thread.Sleep(200);
            //Lấy element của nút Đăng ký, nhấn nút Đăng ký
            driver_47_Nhan.FindElement(By.Id("btnsingup")).Click();

            //Kiểm tra kết quả trả về có thông báo nhập sai/thiếu thông tin không
            Assert.IsTrue(driver_47_Nhan.FindElement(By.ClassName("formErrorContent")).Enabled);
        }
    }
}
