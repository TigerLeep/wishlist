using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishList.Models;
using WishList.ViewModels.Home;

namespace WishList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new WishListContext();
            var users = from u in context.Users
                        orderby u.Name
                        select u;
            return View(users.ToList());
        }

        public ActionResult List(int id)
        {
            var context = new WishListContext();
            var user = (from u in context.Users
                        where u.Id == id
                        select u)
                       .SingleOrDefault();
            var items = (from i in context.Items
                         where i.UserId == id
                         orderby i.Order
                         select i)
                        .ToList();
            var listViewModel = new ListViewModel()
            {
                User = user,
                Items = items.ToList()
            };
            return View(listViewModel);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var context = new WishListContext();
            var user = (from u in context.Users
                        where u.Id == id
                        select u)
                       .SingleOrDefault();
            var item = new Item();
            var createViewModel = new CreateViewModel()
            {
                User = user,
                Item = item
            };
            return View(createViewModel);
        }

        [HttpPost]
        public ActionResult Create(int id, Item item)
        {
            var context = new WishListContext();
            var items = context.Items
                               .Where(i => i.UserId == id);
            var maxOrder = 0M;
            if (items.Any())
            {

                maxOrder = items.Max(i => i.Order);
            }
            var newItem = new Item()
            {
                Description = item.Description,
                Order = maxOrder + 1,
                UserId = id
            };
            context.Items.Add(newItem);
            context.SaveChanges();

            return RedirectToAction("List", new { id = id });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var context = new WishListContext();
            var query = (from i in context.Items
                         where i.Id == id
                         select new { User = i.User, Item = i })
                       .SingleOrDefault();
            var editViewModel = new EditViewModel()
            {
                User = query.User,
                Item = query.Item
            };
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Edit(Item item, int userId)
        {
            var context = new WishListContext();
            var editItem = (from i in context.Items
                            where i.Id == item.Id
                            select i)
                            .SingleOrDefault();
            if (editItem != null)
            {
                editItem.Description = item.Description;
                context.SaveChanges();
            }

            return RedirectToAction("List", new { id = userId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var context = new WishListContext();
            var query = (from i in context.Items
                         where i.Id == id
                         select new { User = i.User, Item = i })
                        .SingleOrDefault();
            var deleteViewModel = new DeleteViewModel()
            {
                User = query.User,
                Item = query.Item
            };
            return View(deleteViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id, int userId)
        {
            var context = new WishListContext();
            var item = (from i in context.Items
                        where i.Id == id
                        select i)
                        .SingleOrDefault();
            if (item != null)
            {
                context.Items.Remove(item);
                context.SaveChanges();
            }
            return RedirectToAction("List", new { id = userId });
        }

        public ActionResult MoveItemUp(int id)
        {
            var context = new WishListContext();
            var item = (from i in context.Items
                        where i.Id == id
                        select i)
                        .SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("List", new { id = item.UserId });
            }

            var previousItem = (from i in context.Items
                                where i.Order < item.Order
                                      && i.UserId == item.UserId
                                orderby i.Order descending
                                select i)
                               .FirstOrDefault();
            if (previousItem == null)
            {
                return RedirectToAction("List", new { id = item.UserId });
            }
            var order = item.Order;
            item.Order = previousItem.Order;
            previousItem.Order = order;
            context.SaveChanges();
            return RedirectToAction("List", new { id = item.UserId });
        }

        public ActionResult MoveItemDown(int id)
        {
            var context = new WishListContext();
            var item = (from i in context.Items
                        where i.Id == id
                        select i)
                        .SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("List", new { id = item.UserId });
            }

            var nextItem = (from i in context.Items
                                where i.Order > item.Order
                                      && i.UserId == item.UserId
                                orderby i.Order
                                select i)
                               .FirstOrDefault();
            if (nextItem == null)
            {
                return RedirectToAction("List", new { id = item.UserId });
            }
            var order = item.Order;
            item.Order = nextItem.Order;
            nextItem.Order = order;
            context.SaveChanges();
            return RedirectToAction("List", new { id = item.UserId });
        }
    }
}
