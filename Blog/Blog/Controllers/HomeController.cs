using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            var lista = new List<Post>();
            using (SqlConnection cnx = ConnectionFactory.CriaConexaoAberta())
            {
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "select * from Posts";
                SqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    Post post = new Post()
                    {
                        Id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"])
                    };
                    lista.Add(post);
                }
            }
            return View(lista);
        }

        public ActionResult NovoPost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaPost(Post post)
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["blog"].ConnectionString;
            using (SqlConnection cnx = ConnectionFactory.CriaConexaoAberta())
            {
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "insert into Posts (Titulo, Resumo, Categoria) values (@titulo, @resumo, @categoria)";
                comando.Parameters.Add(new SqlParameter("Titulo", post.Titulo));
                comando.Parameters.Add(new SqlParameter("Resumo", post.Resumo));
                comando.Parameters.Add(new SqlParameter("Categoria", post.Categoria));
                comando.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}