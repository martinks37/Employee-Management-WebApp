using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using EmployeeApi.Data;
using EmployeeApi.Models;
using ZstdSharp.Unsafe;



namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DatabaseHelper m_objDHelper;
        public EmployeeController(DatabaseHelper objDHelper)
        {
            m_objDHelper = objDHelper;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> lstEmployee = new List<Employee>();
            using (MySqlConnection objconn = m_objDHelper.GetConnection())
            {
                objconn.Open();
                string strQuery = "SELECT * FROM Employee";
                MySqlCommand objCmd = new MySqlCommand(strQuery, objconn);
                MySqlDataReader objReader = objCmd.ExecuteReader();
                while (objReader.Read())
                {
                    Employee objEmployee = new Employee();
                    objEmployee.Name = objReader.GetString("Name");
                    objEmployee.Id = objReader.GetInt32("Id");
                    objEmployee.Position = objReader.GetString("Position");
                    objEmployee.Salary = objReader.GetDouble("salary");
                    lstEmployee.Add(objEmployee);
                }

            }
            return Ok(lstEmployee);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Employee objEmployee = null;
            using (MySqlConnection objconn = m_objDHelper.GetConnection())
            {
                objconn.Open();
                string strQuery = "SELECT * FROM EMPLOYEE WHERE Id = @Id";
                MySqlCommand objCmd = new MySqlCommand(strQuery, objconn);
                objCmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader objReader = objCmd.ExecuteReader();
                if (objReader.Read())
                {

                    objEmployee = new Employee();
                    objEmployee.Name = objReader.GetString("Name");
                    objEmployee.Id = objReader.GetInt32("Id");
                    objEmployee.Position = objReader.GetString("Position");
                    objEmployee.Salary = objReader.GetDouble("salary");
                }


            }
            if (objEmployee == null)
                return NotFound("Employee Not Found");
            return Ok(objEmployee);


        }
        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee objEmployee)
        {
            
            using (MySqlConnection objconn = m_objDHelper.GetConnection())
            {
                objconn.Open();
                string strQuery = "insert into Employee(Name,Position,salary) values (@Name,@Position,@salary)";
                MySqlCommand objCmd = new MySqlCommand(strQuery, objconn);
                
               objCmd.Parameters.AddWithValue("@Name", objEmployee.Name);
                objCmd.Parameters.AddWithValue("@Position", objEmployee.Position);
                objCmd.Parameters.AddWithValue("@salary", objEmployee.Salary);
                objCmd.ExecuteNonQuery();

            }
            return Ok(new { message = "employee Added" });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmp(int id ,[FromBody] Employee objEmployee)
        {
            using (MySqlConnection objconn = m_objDHelper.GetConnection())
            {
                objconn.Open();
                string strQuery = "update Employee set Name=@Name,Position =@Position,salary=@salary where Id =@Id";
                MySqlCommand objCmd = new MySqlCommand(strQuery, objconn);
                objCmd.Parameters.AddWithValue("@Name", objEmployee.Name);
                objCmd.Parameters.AddWithValue("@Position", objEmployee.Position);
                objCmd.Parameters.AddWithValue("@salary", objEmployee.Salary);
                objCmd.Parameters.AddWithValue("@Id", id);
                objCmd.ExecuteNonQuery();
            }
            return Ok(new { message = "Employee Updated " });
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmp(int id)
        {
            using (MySqlConnection objconn = m_objDHelper.GetConnection()) 
            {
                objconn.Open();
                string strQuery = "delete from Employee where Id = @Id ";
                MySqlCommand objCmd = new MySqlCommand(strQuery, objconn);
                objCmd.Parameters.AddWithValue("@Id", id);
                objCmd.ExecuteNonQuery();


            }
            return Ok(new { message = "Deleted That Fool" });
        }


    } 
       
}
