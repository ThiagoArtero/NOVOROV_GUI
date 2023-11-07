using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOVOROV.Context;
using NOVOROV.DatabaseHelper;
using NOVOROV.Models;
using NOVOROV.Models.DropDownLists;
using NOVOROV.ViewModels;
using System.Configuration;


namespace NOVOROV.Controllers
{
    public class AlteracaoTabelasController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly IConfiguration _configuration;

        public AlteracaoTabelasController(RovDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: AlteracaoTabelas
        public ActionResult Index()
        {
            var alteracaoTabelaViewModel = new AlteracaoTabelaViewModel();
            alteracaoTabelaViewModel.AcaoTomada = _context.AcaoTomada;
            alteracaoTabelaViewModel.AcionadoProntoAtendimento = _context.AcionadoProntoAtendimento;
            alteracaoTabelaViewModel.TipoRessarcimento = _context.TipoRessarcimento;
            alteracaoTabelaViewModel.AnaliseConclusao = _context.AnaliseConclusao;
            alteracaoTabelaViewModel.AlarmeRealAcidente = _context.AlarmeRealAcidente;
            alteracaoTabelaViewModel.Detentora = _context.Detentora;
            alteracaoTabelaViewModel.Empresa = _context.Empresa;
            alteracaoTabelaViewModel.EventoERB = _context.EventoERB;
            alteracaoTabelaViewModel.GestaoPerda = _context.GestaoPerda;

            return View(alteracaoTabelaViewModel);
        }

        // GET: AlteracaoTabelas/Details/5
        public ActionResult IndexAcaoTomada(int id, AcaoTomada acaoTomada)
        {
            return View();
        }

        public IActionResult Teste(int id)
        {
            var ocorrencia = _context.Ocorrencia.FindAsync(id);
            return View(ocorrencia);
        }

        public ActionResult IndexAcionadoProntoAtendimento(int id, AcionadoProntoAtendimento acionadoProntoAtendimento)
        {

            return View();
        }

        public ActionResult IndexTipoRessarcimento(int id, TipoRessarcimento tipoRessarcimento)
        {

            return View();
        }

        public ActionResult IndexAnaliseConclusao(int id, AnaliseConclusao analiseConclusao)
        {

            return View();
        }

        public ActionResult IndexAlarmeRealAcidente(int id, AlarmeRealAcidente alarmeRealAcidente)
        {

            return View();
        }

        public ActionResult IndexDetentora(int id, Detentora detentora)
        {

            return View();
        }

        public ActionResult IndexEmpresa(int id, Empresa empresa)
        {

            return View();
        }

        public ActionResult IndexEventoERB(int id, Empresa empresa)
        {

            return View();
        }

        public ActionResult IndexGestaoPerda(int id, GestaoPerda gestaoPerda)
        {
            return View();
        }

        // POST: AlteracaoTabelas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAcaoTomada(string itemName)
        {
            var acaoTomada = new AcaoTomada();
            acaoTomada.NomeAcaoTomada = itemName;
            try
            {
                _context.Add(acaoTomada);
                _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Item adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar item!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAcionadoProntoAtendimento(string itemName)
        {
            var acionadoProntoAtendimento = new AcionadoProntoAtendimento();
            acionadoProntoAtendimento.NomeAcionadoProntoAtendimento = itemName;

            try
            {
                _context.Add(acionadoProntoAtendimento);
                _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Item adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar item!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAnaliseConclusao(string itemName)
        {
            var analiseConclusao = new AnaliseConclusao();
            analiseConclusao.NomeAnaliseConclusao = itemName;

            try
            {
                _context.Add(analiseConclusao);
                _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Item adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar item!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTipoRessarcimento(string itemName)
        {
            var tipoRessarcimento = new TipoRessarcimento();
            tipoRessarcimento.NomeTipoRessarcimento = itemName;

            try
            {
                _context.Add(tipoRessarcimento);
                _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Item adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar item!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAlarmeRealAcidente(string itemName)
        {
            var alarmeRealAcidente = new AlarmeRealAcidente();
            alarmeRealAcidente.NomeAlarmeRealAcidente = itemName;

            try
            {
                _context.Add(alarmeRealAcidente);
                _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Item adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar item!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDetentora(string itemName)
        {
            var detentora = new Detentora();
            detentora.NomeDetentora = itemName;

            try
            {
                _context.Add(detentora);
                _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Item adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar item!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmpresa(string itemName)
        {
            var empresa = new Empresa();
            empresa.NomeEmpresa = itemName;
            try
            {
                _context.Add(empresa);
                _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Item adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar item!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }

        }

        public ActionResult CreateEventoERB(string itemName)
        {
            var eventoERB = new EventoERB();
            eventoERB.NomeEventoERB = itemName;
            try
            {
                _context.Add(eventoERB);
                _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "Item adicionado com sucesso!", notificationType: Notification.success);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar item!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }

        }

        public ActionResult CreateGestaoPerda(string itemName)
        {
            var gestaoPerda = new GestaoPerda();
            gestaoPerda.NomeGestaoPerda = itemName;
            try
            {
                _context.Add(gestaoPerda);
                _context.SaveChangesAsync();
                Notify(title: "Ok!", message: "item adicionado com sucesso!", notificationType: Notification.success);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Notify(title: "Oops!", message: "Erro ao adicionar item!", notificationType: Notification.warning);
                return RedirectToAction(nameof(Index));
            }

        }
        // POST: AlteracaoTabelas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }

        // GET: AlteracaoTabelas/Edit/5

        public ActionResult Edit(int id, string tableName)
        {
            if ((id == null) || (tableName == null))
            {
                //Notify("Algo deu errado ao editar o item!");
                return RedirectToAction("Index", "AlteracaoTabelas");
            }

            string query = $"SELECT ID, Nome{tableName} FROM {tableName} WHERE ID = {id}";

            var database = new Database(_configuration);
            var command = database.GetCommand(query);

            var item = new GenericTabela();

            try
            {
                var reader = command.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    
                    item.Id = Convert.ToInt32(reader["ID"].ToString());
                    item.Nome = reader[$"Nome{tableName}"].ToString();

                }
                reader.Close();
                command.Connection.Close();
            }
            catch (Exception ex)
            {
                command.Connection.Close();
                //_logger.LogError(ex, "exceção gerada enquanto o usuário {user} tentava editar um item na tabela {tableName}", userId, tableName);
                //Notify("Algo deu errado ao editar o item!");
            }
            ViewBag.TableName = tableName;
            return View(item);

        }

        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, string tableName, GenericTabela item)
        {
            if ((id == null) || (id != item.Id))
            {
                //Notify("Algo deu errado ao editar o item!");
                return RedirectToAction("Index", "AlteracaoTabelas");
            }

            var userId = User.Identity.Name.Split("\\")[1];

            try
            {
                string query = "";
                if (tableName == "AcaoTomada")
                {
                    query = $"UPDATE {tableName} SET Nome{tableName} = '{item.Nome}' WHERE ID = {id}";
                }

                if (tableName == "AcionadoProntoAtendimento")
                {
                    query = $"UPDATE {tableName} SET Nome{tableName} = '{item.Nome}' WHERE ID = {id}";
                }

                if (tableName == "TipoRessarcimento")
                {
                    query = $"UPDATE {tableName} SET Nome{tableName} = '{item.Nome}' WHERE ID = {id}";
                }

                if (tableName == "AnaliseConclusao")
                {
                    query = $"UPDATE {tableName} SET Nome{tableName} = '{item.Nome}' WHERE ID = {id}";
                }

                if (tableName == "AlarmeRealAcidente")
                {
                    query = $"UPDATE {tableName} SET Nome{tableName} = '{item.Nome}' WHERE ID = {id}";
                }

                if (tableName == "Detentora")
                {
                    query = $"UPDATE {tableName} SET Nome{tableName} = '{item.Nome}' WHERE ID = {id}";
                }

                if (tableName == "Empresa")
                {
                    query = $"UPDATE {tableName} SET Nome{tableName} = '{item.Nome}' WHERE ID = {id}";
                }

                if (tableName == "EventoERB")
                {
                    query = $"UPDATE {tableName} SET Nome{tableName} = '{item.Nome}' WHERE ID = {id}";
                }

                if (tableName == "GestaoPerda")
                {
                    query = $"UPDATE {tableName} SET Nome{tableName} = '{item.Nome}' WHERE ID = {id}";
                }

                var database = new Database(_configuration);
                var itemSaved = database.ExecuteQuery(query);


            }
            catch (Exception ex)
            {
            }

            return RedirectToAction("Index", "AlteracaoTabelas");
        }




        // GET: AlteracaoTabelas/Delete/5
        public ActionResult DeleteAcaoTomada(int id)
        {
            return View();
        }

        // POST: AlteracaoTabelas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var acaoTomada = await _context.AcaoTomada.FindAsync(id);
            if (acaoTomada != null)
            {
                _context.AcaoTomada.Remove(acaoTomada);
            }
            //_context.Remove(acaoTomada);
            _context.SaveChangesAsync();
            return View(acaoTomada);
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}

