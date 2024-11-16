using NUnit.Framework;
using AltTester.AltTesterUnitySDK.Driver;
using UnityEngine;
using System;
using System.Threading;

public class Testing
{   //Important! If your test file is inside a folder that contains an .asmdef file, please make sure that the assembly definition references NUnit.
    public AltDriver altDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altDriver =new AltDriver();
     
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altDriver.Stop();
    }

    [Test]
    public void SceneChange()
    {
        altDriver.LoadScene("Menu");
        var a = altDriver.WaitForObject(By.NAME, "Play");
        a.Click();
        Assert.IsTrue(altDriver.GetCurrentScene() =="Level");
    }
    [Test]
    public void ScreenLimit() 
    {
        altDriver.LoadScene("Level");
        altDriver.SetTimeScale(1f);
        var a = altDriver.WaitForObject(By.NAME, "Player");
       
        a.worldX = -23.6f;
        a.worldY = 7.87f;
        
        for (int i = 0; i < 10; i++) {
            a.worldX += 1;
           
        }
        AltVector3 pos = a.GetWorldPosition();
        Assert.Less(pos.x,-24);
    }
   
    
    [Test]
    public void CoinDestroys() 
    {
        altDriver.LoadScene("Level");
        altDriver.SetTimeScale(1f);
        var player = altDriver.WaitForObject(By.NAME, "Player");
        var coin = altDriver.WaitForObject(By.NAME, "IceBox");
        player.worldX = -2.75f;
        player.worldY = -5.75f;
        Thread.Sleep(1000);
        Assert.DoesNotThrow(() =>
        {
            altDriver.WaitForObject(By.NAME, "dollar (3)", timeout: 5);
        }, "El objeto no se destruyó en el tiempo esperado.");
    }
        
     

    // Encuentra el objeto Player en la escena por su nombre o etiqueta
    

    // Obtén la posición del player
    

    // Puedes hacer aserciones sobre su posición, por ejemplo:
    

}