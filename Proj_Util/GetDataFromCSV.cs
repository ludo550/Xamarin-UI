using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_Utils
{
    public class GetDataFromCSV
    {
        public static List<Login_DTO> Get_Login_Data_From_CSV(String filePath, String TestName)
        {
            List<Login_DTO> List_LoginDTO = new List<Login_DTO>();
            var reader = new StreamReader(File.OpenRead(filePath));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                if (values[1].ToString().Equals(TestName))
                {
                    Login_DTO LoginGetVal_DTO = new Login_DTO
                    {
                        Id = values[0].ToString(),
                        Username = values[2].ToString(),
                        Password = values[3].ToString(),
                    };
                    List_LoginDTO.Add(LoginGetVal_DTO);
                }
            }
            return List_LoginDTO;
        }
    }
}
