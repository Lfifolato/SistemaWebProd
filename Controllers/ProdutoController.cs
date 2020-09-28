using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaMvc.Models;
using SistemaWebProd.Data;

namespace SistemaWebProd.Controllers
{
    public class ProdutoController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Produto
        public async Task<ActionResult> Index()
        {
            var produtos = db.Produtos.Include(p => p.Fornecedor);
            return View(await produtos.ToListAsync());
        }

        // GET: Produto/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.IdFornecedor = new SelectList(db.Fornecedors, "Id", "Nome");
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Valor,Dvencimento,IdFornecedor,Tipo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdFornecedor = new SelectList(db.Fornecedors, "Id", "Nome", produto.IdFornecedor);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFornecedor = new SelectList(db.Fornecedors, "Id", "Nome", produto.IdFornecedor);
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Valor,Dvencimento,IdFornecedor,Tipo")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdFornecedor = new SelectList(db.Fornecedors, "Id", "Nome", produto.IdFornecedor);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = await db.Produtos.FindAsync(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Produto produto = await db.Produtos.FindAsync(id);
            db.Produtos.Remove(produto);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
