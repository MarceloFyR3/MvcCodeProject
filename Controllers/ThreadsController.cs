using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoMvc.Models;

namespace ProjetoMvc.Controllers
{
    public class ThreadsController : Controller
    {
        // GET: Threads
        public ActionResult Index()
        {
            CarregarSelect();

            return View();
        }

        [HttpPost]
        public ActionResult Index(Threads formView)
        {
            int tipoexemplo = Convert.ToInt32(formView.ddlTipo);
            var erro = formView.ErroSelect;

            if (tipoexemplo == 0)
            {

            }

            CarregarSelect();

            return View(formView);
        }

        private void CarregarSelect()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "--Selecione--", Value = "0" });
            li.Add(new SelectListItem { Text = "Single-Threads", Value = "1" });
            li.Add(new SelectListItem { Text = "Multi-Threads", Value = "2" });
            li.Add(new SelectListItem { Text = "Multi-Threads Assincrôno", Value = "3" });

            ViewData["tipoThreads"] = li;
        }

        private static void InstanciaThread()
        {
            System.Diagnostics.Debug.WriteLine("Thread principal iniciada");
            Thread.CurrentThread.Name = "Principal - ";

            Thread t1 = new Thread(new ThreadStart(run));
            t1.Name = "Secundária - ";
            t1.Start();

            for (int i = 0; i < 5; i++)
            {
                System.Diagnostics.Debug.WriteLine("Thread atual  - " + Thread.CurrentThread.Name + i);
                //Console.WriteLine();
                Thread.Sleep(1000);

            }
            System.Diagnostics.Debug.WriteLine("Thread Principal terminada");
        }

        public static void run()
        {
            for (int i = 0; i < 5; i++)
            {
                System.Diagnostics.Debug.WriteLine("Thread Atual - " + Thread.CurrentThread.Name + i);

                Thread.Sleep(1000);
            }
        }

        //Multi Threads
        private void MultiThreads()
        {
            System.Diagnostics.Debug.WriteLine("======MultiThreads======");

            Thread[] Threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                Threads[i] = new Thread(new ThreadStart(PrintNumbers));
                Threads[i].Name = "threadFilha " + i;
            }

            foreach (Thread t in Threads)
                t.Start();
        }

        public void PrintNumbers()
        {
            //A palavra-chave lock obriga-nos a especificar um token (uma referência de objeto) 
            //que deve ser adquirido por uma thread para entrar no escopo do lock (bloqueio). 
            //Quando estamos tentando bloquear um método em nível de instância, podemos simplesmente passar a referência a essa instância.
            //(Nós podemos usar esta palavra-chave para bloquear o objeto atual) Uma vez que a thread entra em um escopo de bloqueio, 
            //o sinal de trava (objeto de referência) é inacessível por outros segmentos, 
            //até que o bloqueio seja liberado ou o escopo do bloqueio seja encerrado.
            //lock (this)
            //{
            //    for (int i = 0; i < 5; i++)
            //    {
            //        Thread.Sleep(100);
            //        System.Diagnostics.Debug.Write(i + ",");
            //    }
            //}


            //Método Monitor.Enter() é o destinatário final do token da thread.Precisamos escrever 
            //todo o código do escopo de bloqueio dentro de um bloco try. A cláusula finally assegura
            //que o token de thread seja liberada (usando o método Monitor.Exit(), independentemente de qualquer exceção de runtime.
            //Monitor.Enter(this);
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    System.Diagnostics.Debug.Write(i + ",");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
    }
}