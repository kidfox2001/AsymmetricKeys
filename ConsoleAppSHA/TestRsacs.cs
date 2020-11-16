using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSHA
{
    class TestRsacs
    {
        static void Main(string[] args)
        {
            //var KeyPublish = File.ReadAllText("KeyPublish.dat");
            //var KeyPrivate = File.ReadAllText("KeyPrivate.dat");

            RSAUtil rsa = new RSAUtil("baby");

            //File.WriteAllText("KeyPublish.dat", rsa.KeyPrivate);
            //File.WriteAllText("KeyPrivate.dat", rsa.KeyPrivate);

            var encryptData =  rsa.EncryptData("hello peter && near");
            var result = rsa.DecryptData(encryptData);


            rsa.ChangeKey("god");


            var  encryptData2 = rsa.EncryptData("yyyy");
           var  result2 = rsa.DecryptData(encryptData);


            File.WriteAllBytes("encryptData.dat", encryptData);

         


            


            var a = 0;
        }

    }
}
