using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NOVOROV.Context;
using NOVOROV.DatabaseHelper;
using NOVOROV.Models;

namespace NOVOROV.Controllers
{
    public class LogsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly RovDbContext _context;

        public LogsController(IConfiguration configuration, RovDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            string query = $"Select Id, Message, Level, TimeStamp, Properties, Acao, UsuarioOperador, IpOperador, Hostname, ConteudoAnterior, ConteudoAtual, Campo, U.UsuarioId, U.NomeUsuario, ROV " +
                $"From Logs " +
                $" INNER JOIN Usuario U"+
                $" ON UsuarioOperador = U.UsuarioId " +
                $" Where UsuarioOperador != 'null'";

            var database = new Database(_configuration);
            var command = database.GetCommand(query);

            List<Logs> items = new List<Logs>();
            
            try

            {
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Logs item = new Logs();
                    item.TimeStamp = reader["TimeStamp"].ToString();
                    item.Message = reader["Message"].ToString();
                    item.Acao = reader["Acao"].ToString();
                    item.IpOperador = reader["IpOperador"].ToString();
                    item.Hostname = reader["Hostname"].ToString();
                    item.UsuarioOperador = reader["NomeUsuario"].ToString();
                    item.ConteudoAnterior = reader["ConteudoAnterior"].ToString();
                    item.ConteudoAtual = reader["ConteudoAtual"].ToString();
                    item.Campo = reader["Campo"].ToString();
                    item.ROV = reader["ROV"].ToString();

                    items.Add(item);
                }

                reader.Close();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                command.Connection.Close();
            }

            return View(items);
        }

        public async Task<IActionResult> LogValores()
        {

            List<Ocorrencia> ocorrencias = new List<Ocorrencia>();

            var userId = User.Identity.Name.Split("\\")[1];

            ocorrencias = await _context.Ocorrencia
                .Include(o => o.TipoOcorrencia)
                .Include(o => o.TipoSite)
            .ToListAsync();
            return View(ocorrencias);
        }

        public FileResult ExportFile()
        {
            var userId = User.Identity.Name.Split("\\")[1];





            string query = $"Select Id, Message, Level, TimeStamp, Properties, Acao, UsuarioOperador, IpOperador, Hostname, ConteudoAnterior, ConteudoAtual, Campo, U.UsuarioId, U.NomeUsuario, ROV " +
                $"From Logs " +
                $" INNER JOIN Usuario U" +
                $" ON UsuarioOperador = U.UsuarioId " +
                $" Where UsuarioOperador != 'null'";



            var database = new Database(_configuration);
            var command = database.GetCommand(query);



            List<Logs> items = new List<Logs>();



            try



            {
                var reader = command.ExecuteReader();



                while (reader.Read())
                {
                    Logs item = new Logs();
                    item.TimeStamp = reader["TimeStamp"].ToString();
                    item.Message = reader["Message"].ToString();
                    item.Acao = reader["Acao"].ToString();
                    item.IpOperador = reader["IpOperador"].ToString();
                    item.Hostname = reader["Hostname"].ToString();
                    item.UsuarioOperador = reader["NomeUsuario"].ToString();
                    item.ConteudoAnterior = reader["ConteudoAnterior"].ToString();
                    item.ConteudoAtual = reader["ConteudoAtual"].ToString();
                    item.Campo = reader["Campo"].ToString();
                    item.ROV = reader["ROV"].ToString();



                    items.Add(item);
                }



                reader.Close();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                command.Connection.Close();
            }





            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Logs");



                var currentRow = 1;



                worksheet.Cell(currentRow, 1).Value = "Data Alteração";
                worksheet.Cell(currentRow, 2).Value = "Rov";
                worksheet.Cell(currentRow, 3).Value = "Ação";
                worksheet.Cell(currentRow, 4).Value = "Usuário Operador";
                worksheet.Cell(currentRow, 5).Value = "Ip Operador";
                worksheet.Cell(currentRow, 6).Value = "Hostname";
                worksheet.Cell(currentRow, 7).Value = "Campo";
                worksheet.Cell(currentRow, 8).Value = "Conteúdo Anterior";
                worksheet.Cell(currentRow, 9).Value = "Conteúdo Atual";




                foreach (var log in items)
                {
                    currentRow++;



                    worksheet.Cell(currentRow, 1).Value = log.TimeStamp;
                    worksheet.Cell(currentRow, 2).Value = log.ROV;
                    worksheet.Cell(currentRow, 3).Value = log.Acao;
                    worksheet.Cell(currentRow, 4).Value = log.UsuarioOperador;
                    worksheet.Cell(currentRow, 5).Value = log.IpOperador;
                    worksheet.Cell(currentRow, 6).Value = log.Hostname;
                    worksheet.Cell(currentRow, 7).Value = log.Campo;
                    worksheet.Cell(currentRow, 8).Value = log.ConteudoAnterior;
                    worksheet.Cell(currentRow, 9).Value = log.ConteudoAtual;



                }



                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"logs-{DateTime.Now:dd/MM/yyyy}.xlsx");
                }



            }





        }

    }
}
