using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Proj_Utils;
using NUnit.Framework.Interfaces;
using Xam_Proj_Pages;
using System.Collections.Generic;
using Res = ClassLibrary1.Res_Env;

namespace Xam_Proj_Global
{
    public class AppInitializer
    {
        public static IApp app;
        public static Platform Platform;
        public static Login_Interface Obj = null;
        public static String FailedStep = null;

        public void StartApp(String device)
        {
                if (device == "note5")
                {
                    Platform = Platform.Android;
                app = ConfigureApp
                    .Android.DeviceSerial("emulator-5554")
                    .ApkFile(@"D:\Android_ORB_Staging_Bethpage_origin.release.2016.07.apk").EnableLocalScreenshots().LogDirectory(@"C:\ExtentReport")
                    .StartApp();
                        
                     Obj = new Test_Obj_Android(app);
                }
                else if (device == "note8")
                {
                    Platform = Platform.Android;
                    app = ConfigureApp
                        .Android.DeviceSerial("note8")
                        .StartApp();
                     Obj = new Test_Obj_Android(app);
                 }
                if (device == "iphone7")
                {
                    Platform = Platform.iOS;
                    app = ConfigureApp
                        .iOS.DeviceIdentifier("iphone7")
                        .StartApp();
                    Obj = new Test_Obj_iOs(app);
                }
                else if (device == "iphone8")
                {
                    Platform = Platform.iOS;
                    app = ConfigureApp
                            .iOS.DeviceIdentifier("iphone8")
                            .StartApp();
                     Obj = new Test_Obj_iOs(app);

                }
        }

        public static IEnumerable<String> Devicetorun()
        {
            String[] browsers = Res.Devices.Split(',');
            foreach (String b in browsers)
            {
                yield return b;
            }
        }

        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest test;
        public static int rprtCtr = 1;

        public void SetupReport()
        {
            if (!Directory.Exists(@"C:\ExtentReport"))
            {
                Directory.CreateDirectory(@"C:\ExtentReport");
            }
            htmlReporter = new ExtentHtmlReporter(@"C:\ExtentReport\Sitecore_Android.html");
            htmlReporter.Configuration().Theme = Theme.Standard;
            htmlReporter.Configuration().DocumentTitle = "Xamarin UI Test";
            htmlReporter.Configuration().ReportName = "Xamarin - Report";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            rprtCtr++;
        }

        [TearDown]
        public void CloseApp()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                string screenShotPath = CommonFunctions.CaptureScreen(app);
                test.Log(Status.Fail, stackTrace + errorMessage);
                test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath));
            }
            extent.Flush();
            
        }

    }
}

