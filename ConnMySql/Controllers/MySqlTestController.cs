using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ConnMySql.model;

namespace ConnMySql.Controllers
{
    [Route("api/[controller]")]
    public class MySqlTestController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<MyTable> Get()
        {
            List<MyTable> models = new List<MyTable>();
            int i = 0;
            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=test;uid=root;pwd=123456;"))
            {
                con.Open();
                string sql = "select * from Mytable ";
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            MyTable model = new MyTable();
                            model.Id = (int)dr["Id"];
                            model.Name = dr["Name"].ToString();
                            model.Age = (int)dr["Age"];
                            model.Content = dr["Content"].ToString();
                            models.Add(model);
                        }
                    }
                }
            }
            return models;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            int i = 0;
            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=test;uid=root;pwd=123456;"))
            {
                con.Open();
                string sql = "insert into Mytable(name,age,content) values('zhou','25','http://www.cnblogs.com/chengxuzhimei')";
                using (MySqlCommand com = new MySqlCommand(sql, con))
                {
                    i = com.ExecuteNonQuery();
                }
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
