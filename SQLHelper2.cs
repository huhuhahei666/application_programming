using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

namespace WinForms_singleselection
{
    public class SQLHelper
    {
        private readonly string _connectionString;

        public SQLHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 通用执行方法
        

        // 查询数据
        public DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddRange(parameters);
                adapter.Fill(dt);
            }
            return dt;
        }

        // 执行标量查询（返回单个值）
        public object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddRange(parameters);
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        public int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                cmd.Parameters.AddRange(parameters); // 关键：绑定参数
                return cmd.ExecuteNonQuery();
            }
        }
        public void SaveProblemNote(int studentId, string problemId, string note)
        {
            const string sql = @"
    IF EXISTS (SELECT 1 FROM StudentProblem WHERE StuID = @StuID AND problem_id = @problem_id)
        UPDATE StudentProblem SET Notes = @Notes 
        WHERE StuID = @StuID AND problem_id = @problem_id
    ELSE
        INSERT INTO StudentProblem (StuID, problem_id, Notes)
        VALUES (@StuID, @problem_id, @Notes)";

            ExecuteNonQuery(sql,
                new SqlParameter("@StuID", studentId),
                new SqlParameter("@problem_id", problemId),
                new SqlParameter("@Notes", note ?? (object)DBNull.Value));
        }

        public string GetProblemNote(int studentId, string problemId)
        {
            const string sql = "SELECT Notes FROM StudentProblem WHERE StuID = @StuID AND problem_id = @problem_id";

            var result = ExecuteScalar(sql,
                new SqlParameter("@StuID", studentId),
                new SqlParameter("@problem_id", problemId));

            return result == null || result == DBNull.Value ? string.Empty : result.ToString();
        }
    }
}
