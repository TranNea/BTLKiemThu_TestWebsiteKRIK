using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.DevTools.V122.Database;

namespace _47_Nhan_N1_DangNhap
{
    //Test chức năng Đăng nhập tài khoản

    [TestClass]
    public class Login_47_Nhan_N1
    {
        //47_Nhan_N1
        //Test case 1 - Đăng nhập tài khoản thành công
        [TestMethod]
        public void TC1_DangNhapThanhCong_47_Nhan()
        {
            //Tắt màn đen
            ChromeDriverService chrome_47_Nhan = ChromeDriverService.CreateDefaultService();
            chrome_47_Nhan.HideCommandPromptWindow = true;

            //Điều hướng trình duyệt
            IWebDriver driver_47_Nhan = new ChromeDriver(chrome_47_Nhan);
            driver_47_Nhan.Navigate().GoToUrl("https://krik.vn/");

            ////Lấy element của quảng cáo để tắt quảng cáo
            //Thread.Sleep(2000);
            //driver_47_Nhan.FindElement(By.ClassName("modal-dialog")).Click();

            //Lấy element của Tài khoản
            Thread.Sleep(4000);
            //driver_47_Nhan.FindElement(By.ClassName("showcustomer")).Click();

            var element = driver_47_Nhan.FindElement(By.ClassName("showcustomer"));  // tìm phần tử muốn click
            ((IJavaScriptExecutor)driver_47_Nhan).ExecuteScript("arguments[0].click();", element);

            //Lấy element các trường thông tin để đăng nhập

            //Lấy element của trường Tên đăng nhập
            Thread.Sleep(1000);
            driver_47_Nhan.FindElement(By.CssSelector("input[type='text']")).SendKeys("2151050296nhan@ou.edu.vn");

            //Lấy element của trường Mật khẩu
            Thread.Sleep(1000);
            driver_47_Nhan.FindElement(By.CssSelector("input[type='password']")).SendKeys("Nhan47");

            //Lấy element của nút Đăng nhập
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.Id("btnsignin")).Click();
        }


        //47_Nhan_N1
        //Test case 2 - Đăng nhập tài khoản không thành công
        /*
         * Test case 2.1 - Đăng nhập tài khoản với email sai
         * Test case 2.2 - Đăng nhập tài khoản với mật khẩu sai
         * Test case 2.3 - Đăng nhập tài khoản mà không nhập dữ liệu
         * Test case 2.4 - Đăng nhập tài khoản với email rỗng
         * Test case 2.5 - Đăng nhập tài khoản với mật khẩu rỗng
         */

        //Lấy dữ liệu từ file RegisterData_47_Nhan.csv
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                         @".\LoginData\LoginData_47_Nhan.csv", "LoginData_47_Nhan#csv", DataAccessMethod.Sequential)]

        [TestMethod]
        public void TC2_DangNhapKhongThanhCong_47_Nhan()
        {
            //Gán dữ liệu cho các trường thông tin
            var username = TestContext.DataRow[0].ToString(); //Tên đăng nhập
            var password = TestContext.DataRow[1].ToString(); //Mật khẩu

            //Tắt màn đen
            ChromeDriverService chrome_47_Nhan = ChromeDriverService.CreateDefaultService();
            chrome_47_Nhan.HideCommandPromptWindow = true;

            //Điều hướng trình duyệt
            IWebDriver driver_47_Nhan = new ChromeDriver(chrome_47_Nhan);
            driver_47_Nhan.Navigate().GoToUrl("https://krik.vn/");

            ////Lấy element của quảng cáo để tắt quảng cáo
            //Thread.Sleep(2000);
            //driver_47_Nhan.FindElement(By.ClassName("modal-dialog")).Click();

            //Lấy element của Tài khoản
            Thread.Sleep(2000);
            //driver_47_Nhan.FindElement(By.ClassName("showcustomer")).Click();
            var element = driver_47_Nhan.FindElement(By.ClassName("showcustomer"));  // tìm phần tử muốn click
            ((IJavaScriptExecutor)driver_47_Nhan).ExecuteScript("arguments[0].click();", element);

            //Lấy element các trường thông tin để đăng nhập

            //Lấy element của trường Tên đăng nhập
            Thread.Sleep(1000);
            driver_47_Nhan.FindElement(By.CssSelector("input[type='text']")).SendKeys(username);

            //Lấy element của trường Mật khẩu
            Thread.Sleep(1000);
            driver_47_Nhan.FindElement(By.CssSelector("input[type='password']")).SendKeys(password);

            //Lấy element của nút Đăng nhập
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.Id("btnsignin")).Click();

            //Kiểm tra kết quả trả về có thông báo nhập sai/thiếu thông tin không
            Assert.IsTrue(driver_47_Nhan.FindElement(By.ClassName("formErrorContent")).Enabled);
        }


        //47_Nhan_N1
        //Test case 3 - Đăng nhập bằng tài khoản Google
        [TestMethod]
        public void TC3_DangNhapTaiKhoanGoogle_47_Nhan()
        {
            //Tắt màn đen
            ChromeDriverService chrome_47_Nhan = ChromeDriverService.CreateDefaultService();
            chrome_47_Nhan.HideCommandPromptWindow = true;

            //Điều hướng trình duyệt
            IWebDriver driver_47_Nhan = new ChromeDriver(chrome_47_Nhan);
            driver_47_Nhan.Navigate().GoToUrl("https://krik.vn/");

            ////Lấy element của quảng cáo để tắt quảng cáo
            //Thread.Sleep(2000);
            //driver_47_Nhan.FindElement(By.ClassName("modal-dialog")).Click();

            //Lấy element của Tài khoản
            Thread.Sleep(2000);
            //driver_47_Nhan.FindElement(By.ClassName("showcustomer")).Click();
            var element = driver_47_Nhan.FindElement(By.ClassName("showcustomer"));  // tìm phần tử muốn click
            ((IJavaScriptExecutor)driver_47_Nhan).ExecuteScript("arguments[0].click();", element);

            // Lấy element của nút Đăng nhập bằng Google
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.CssSelector("#formAcount > div.user-foot.text-center > li.loginGg > a")).Click();

            //Lấy element của trường Email
            Thread.Sleep(1000);
            driver_47_Nhan.FindElement(By.CssSelector("input[type='email']")).SendKeys("2151050296nhan@ou.edu.vn");

            ////Lấy element của nút Next trường Email
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.CssSelector("#identifierNext > div > button")).Click();

            //Xóa phiên bản khác của Webdriver đang chạy ngầm
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("ChromeWebDriver"))
            {
                process.Kill();
            }

            //Lấy element của trường Mật khẩu
            Thread.Sleep(4000);
            driver_47_Nhan.FindElement(By.Name("Passwd")).SendKeys("nhan318**");

            //Lấy element của nút Next trường Mật khẩu
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.CssSelector("#passwordNext > div > button")).Click();

            //Lấy element của nút Tiếp tục
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.CssSelector("#yDmH0d > c-wiz > div > div.JYXaTc.F8PBrb > div > div > div:nth-child(2) > div > div > button")).Click();
        }


        //47_Nhan_N1
        //Test case 4 - Đăng nhập bằng tài khoản Facebook
        [TestMethod]
        public void TC4_DangNhapTaiKhoanFacebook_47_Nhan()
        {
            //Tắt màn đen
            ChromeDriverService chrome_47_Nhan = ChromeDriverService.CreateDefaultService();
            chrome_47_Nhan.HideCommandPromptWindow = true;

            //Điều hướng trình duyệt
            IWebDriver driver_47_Nhan = new ChromeDriver(chrome_47_Nhan);
            driver_47_Nhan.Navigate().GoToUrl("https://krik.vn/");

            ////Lấy element của quảng cáo để tắt quảng cáo
            //Thread.Sleep(2000);
            //driver_47_Nhan.FindElement(By.ClassName("modal-dialog")).Click();


            //Lấy element của Tài khoản
            Thread.Sleep(2000);
            //driver_47_Nhan.FindElement(By.ClassName("showcustomer")).Click();
            var element = driver_47_Nhan.FindElement(By.ClassName("showcustomer"));  // tìm phần tử muốn click
            ((IJavaScriptExecutor)driver_47_Nhan).ExecuteScript("arguments[0].click();", element);

            // Lấy element của nút Đăng nhập bằng Facebook
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.CssSelector("#formAcount > div.user-foot.text-center > li.loginFb > a")).Click();

            //Lấy element của trường Email
            Thread.Sleep(1000);
            driver_47_Nhan.FindElement(By.CssSelector("input[type='text']")).SendKeys("hoainhan318@gmail.com");

            //Lấy element của trường Mật khẩu
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.CssSelector("input[type='password']")).SendKeys("Nhan318//");

            //Lấy element của nút Đăng nhập
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.Id("loginbutton")).Click();
        }
    }
}
