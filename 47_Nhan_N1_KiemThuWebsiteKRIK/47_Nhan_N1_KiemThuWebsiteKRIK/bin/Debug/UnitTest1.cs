using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace _47_Nhan_N1_KiemThuWebsiteKRIK
{
    //Test chức năng Đăng ký tài khoản

    [TestClass]
    public class UnitTest1
    {
        //Test case 1 - Đăng ký tài khoản thành công
        [TestMethod]
        public void TC1_47_Nhan()
        {
            //Tắt màn đen
            ChromeDriverService chrome_47_Nhan = ChromeDriverService.CreateDefaultService();
            chrome_47_Nhan.HideCommandPromptWindow = true;

            //Điều hướng trình duyệt
            IWebDriver driver_47_Nhan = new ChromeDriver(chrome_47_Nhan);
            driver_47_Nhan.Navigate().GoToUrl("https://krik.vn/");

            //Lấy element của quảng cáo để tắt quảng cáo
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.ClassName("modal-dialog")).Click();

            //Lấy element của Tài khoản
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.ClassName("showcustomer")).Click();

            //Lấy element của Đăng ký
            Thread.Sleep(2000);
            driver_47_Nhan.FindElement(By.XPath("//*[@id=\"root\"]/main/div/div/a[@href='/user/signup']")).Click();
        }
    }
}
