using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xam_Proj_Global;
using Xam_Proj_Pages;
using Proj_Utils;
using AventStack.ExtentReports;
using System.Collections.Generic;
using CTest = ClassLibrary1.TestDrivenSteps.Login_Xam_Fail;

namespace Xam_Test
{
    [TestFixture]
    public class Tests : AppInitializer
    {
        [TestCaseSource(typeof(AppInitializer), "Devicetorun")]
        public void Login_Xam_Fail(String Device)
        {
            #region Variable Declaration
            List<Login_DTO> LoginData= new List<Login_DTO>();
            Login_DTO LD = new Login_DTO();
            String testDirectory = TestContext.CurrentContext.WorkDirectory.Substring(0, TestContext.CurrentContext.WorkDirectory.LastIndexOf(@"\UITest2\bin\Debug"));
            #endregion

            LoginData = GetDataFromCSV.Get_Login_Data_From_CSV(testDirectory + @"\Data\Login.csv", "AppLaunches");
            for (int i = 0; i < LoginData.Count; i++)
            {
                #region Store Values from csv
                try
                {
                    LD = LoginData[i];
                }
                catch (Exception ex)
                {

                    test.Log(Status.Fail, ex.Message.ToString());

                    Assert.Fail();
                }
                #endregion

                #region Setup Report
                SetupReport();
                test = extent.CreateTest(NUnit.Framework.TestContext.CurrentContext.Test.Name.ToString());
                #endregion

                #region Launch App
                try
                {
                    test.Log(Status.Debug, CTest.Step1);//Verify that the app can be Launched
                    FailedStep = CTest.Step1;
                    StartApp(Device);
                    test.AssignCategory(Platform.ToString());
                    app.WaitForElement(Obj.Username(), "Timed Out", TimeSpan.FromSeconds(4.00));
                    test.Log(Status.Pass, CTest.Step1.Replace("Launch", "Launched"));
                }
                catch (Exception ex)
                {
                    test.Log(Status.Fail, CTest.Step1 +" failed because, " + ex.StackTrace);
                    Assert.Fail();
                }
                #endregion

                #region Login to the App
                try
                {
                    test.Log(Status.Debug, CTest.Step2 + " with: " + LD.Username);//Verify that User can log in
                    
                    test.Log(Status.Info, CTest.Step2_1);//Verify that user can enter the Username
                    FailedStep = CTest.Step2_1;
                    app.EnterText(Obj.Username(), LD.Username);
                    test.Log(Status.Pass, CTest.Step2_1.Replace("Verify","Verified") + " with " + LD.Username);
                    
                    test.Log(Status.Info, CTest.Step2_2);//Verify that user can enter Password
                    FailedStep = CTest.Step2_2;
                    app.EnterText(Obj.Password(), LD.Password);
                    test.Log(Status.Pass, CTest.Step2_2.Replace("Verify", "Verified"));
                }
                catch (Exception ex)
                {
                    test.Log(Status.Fail, CTest.Step2+ " failed as automation couldn't " + FailedStep.ToLower() + " because, " + ex.StackTrace);
                    Assert.Fail();
                }
                #endregion

            }
        }
    }
}

