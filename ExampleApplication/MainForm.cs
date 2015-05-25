using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibDataAccess.DAL;
using ExampleModel.Entity;
using System.Data.SqlClient;
using log4net;
using System.Data.Entity.Validation;
using System.Transactions;
using LibDataAccess.Extension;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections;
using AutoMapper;
using ExampleApplicationCSharp.Logging;
using ExampleApplicationCSharp.Service;
using ExampleApplicationCSharp.AutoMapper;
using ExampleApplicationCSharp.Extension;
using System.Security.Principal;
using ExampleApplication.ViewModel;

namespace ExampleApplicationCSharp
{
    public partial class MainForm : Form
    {
        private ILog logger = LogManager.GetLogger(typeof(MainForm).Name);

        public MainForm()
        {
            InitializeComponent();
        }

        private void CRUDForm_Load(object sender, EventArgs e)
        {
            //自訂log4net的Properties值, 於開發環境將改為登入者ID
            GlobalContext.Properties["UserId"] = Environment.MachineName;
        }

        #region demo區, 實際撰寫請參考範例區

        private void btnDemo_Click(object sender, EventArgs e)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                //取得資料
                List<Products> product = db.Products.Take(5).ToList();
                DataGridView1.DataSource = product;

                //修改
                Products firstProduct = db.Products.First();
                firstProduct.ProductName = DateTime.Now.ToString("HH:mm:ss.fff");

                db.SaveChanges();

                //新增
                Region region = new Region
                {
                    RegionID = 50,
                    RegionDescription = "test"
                };

                db.Region.Add(region);
                db.SaveChanges();

                //刪除
                Region lastRegion = db.Region.ToList().Last();
                db.Region.Remove(lastRegion);
                db.SaveChanges();
            }
        }

        private void btnEagerLoading_Click(object sender, EventArgs e)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                logger.Debug("lazy loading");
                //僅取得指定Entity
                Categories catLazy = db.Categories.First();
                //於需要巡覽導覽屬性時, 才會產生sql去資料庫查詢
                foreach (var depUser in catLazy.Products)
                {

                }

                logger.Debug("eager loading");
                //取得指定Entity, 並明確指定include導覽屬性                
                Categories catEager = db.Categories.Include(p => p.Products).First();
                //於需要巡覽導覽屬性時, 不會產生額外的sql查詢
                foreach (var depUser in catEager.Products)
                {

                }
            }
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                //更新
                Products firstProduct = db.Products.First();

                logger.Debug(string.Format("before update, state: {0}, original value: {1}, current value: {2}",
                                         db.Entry<Products>(firstProduct).State,
                                         db.Entry<Products>(firstProduct).OriginalValues["ProductName"],
                                         db.Entry<Products>(firstProduct).CurrentValues["ProductName"]));

                firstProduct.ProductName = DateTime.Now.ToString("HH:mm:ss.fff");

                logger.Debug(string.Format("after update, state: {0}, original value: {1}, current value: {2}",
                                         db.Entry<Products>(firstProduct).State,
                                         db.Entry<Products>(firstProduct).OriginalValues["ProductName"],
                                         db.Entry<Products>(firstProduct).CurrentValues["ProductName"]));

                db.SaveChanges();

                logger.Debug(string.Format("after save change, state: {0}, original value: {1}, current value: {2}",
                                         db.Entry<Products>(firstProduct).State,
                                         db.Entry<Products>(firstProduct).OriginalValues["ProductName"],
                                         db.Entry<Products>(firstProduct).CurrentValues["ProductName"]));


                //新增
                Products newProduct = new Products
                {                    
                    ProductName = DateTime.Now.ToString("HH:mm:ss.fff")
                };

                logger.Debug(string.Format("before add, state: {0}", db.Entry<Products>(newProduct).State));

                db.Products.Add(newProduct);

                logger.Debug(string.Format("after add, state: {0}", db.Entry<Products>(newProduct).State));

                db.SaveChanges();

                logger.Debug(string.Format("after save change, state: {0}", db.Entry<Products>(newProduct).State));
            }
        }

        #region 這四個method是一組泛型的範例

        private void btnGeneric_Click(object sender, EventArgs e)
        {
            //弱型別
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(100.523);
            arrayList.Add("abc");

            foreach (object o in arrayList)
            {
                //使用時須再轉型                
            }

            //強型別
            List<int> intList = new List<int>();
            intList.Add(1);
            //以下會發生編譯錯誤
            //intList.Add(100.523);
            //intList.Add("abc");

            foreach (int i in intList)
            {
                //使用時不需要再轉型
            }

            string intToStr = GenericCombineString<int>(10, 20);
            logger.Debug(intToStr);

            string decimalToStr = GenericCombineString<decimal>(10.24M, 20.532M);            
            logger.Debug(decimalToStr);
        }

        //只能給int用
        private string IntToString(int item, int item2)
        {
            return string.Format("{0}, {1}", item, item2);
        }

        //只能給decimal用
        private string DecToString(decimal item, decimal item2)
        {
            return string.Format("{0}, {1}", item, item2);
        }

        //泛型method
        private string GenericCombineString<T>(T item, T item2)            
        {            
            return string.Format("{0}, {1}", item, item2);
        }

        #endregion

        private void btnCompare_Click(object sender, EventArgs e)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                //IEnumerable會撈出所有資料, 再於記憶體中作篩選
                List<string> list = db.Products.AsEnumerable()
                                               .Where(p => p.UnitPrice > 10).Take(5).Select(p => p.ProductName).ToList();

                //IQueryable會將所有篩選轉成SQL, 再至資料庫中執行
                List<string> list2 = db.Products.AsQueryable()
                                                .Where(p => p.UnitPrice > 10).Take(5).Select(p => p.ProductName).ToList();

                logger.Debug(String.Format("IEnumerable: {0}", String.Join(",", list.ToArray())));
                logger.Debug(String.Format("IQueryable: {0}", String.Join(",", list2.ToArray())));

            }
        }

        private void btnAnonymousType_Click(object sender, EventArgs e)
        {
            //匿名型別
            var item = new { Id = 1, Name = "1st Item" };

            logger.Debug(item.GetType());

            //匿名型別陣列
            var itemArray = new[] { 
                new { Id = 3, Name = "3rd Item" },
                new { Id = 5, Name = "5th Item" }
            };

            logger.Debug(itemArray.GetType());

            foreach (var i in itemArray)
            {
                logger.Debug(string.Format("{0}: {1}", i.Id, i.Name));
            }

            using (NorthwindEntities db = new NorthwindEntities())
            {
                //匿名型別搭配linq使用
                var query = from data in db.Products
                            select new
                            {
                                ID = data.ProductID,
                                Name = data.ProductName
                            };

                DataGridView1.DataSource = query.ToList();
            }
        }

        #region 這兩個method是一組delegate的範例

        private void btnDelegate_Click(object sender, EventArgs e)
        {
            logger.Debug("delegate");
            Counting counting = new Counting();

            //使用CountingAlert這個delegate型別建立新的delegate實體, 並將參考指向Alert這個method
            Counting.CountingNotify del = new Counting.CountingNotify(Alert);
            //將delegate實體加入至Class中同型別的delegate Field中
            counting.notifyHandler += del;            
        }

        /// <summary>
        /// delegate的實際邏輯
        /// </summary>
        /// <param name="currentNum"></param>
        private void Alert(int currentNum)
        {
            int limit = 5;
            logger.DebugFormat("current num: {0}, limit: {1}", currentNum, limit);

            if (currentNum > limit)
            {
                logger.DebugFormat("currnet num > {0}", limit);
            }
        }

        #endregion                

        private void btnAnonymous_Click(object sender, EventArgs e)
        {
            logger.Debug("anonymous delegate");
            Counting counting = new Counting();

            //使用CountingAlert這個delegate型別建立新的delegate實體, 並將參考指向匿名方法
            Counting.CountingNotify del = delegate(int currentNum)
            {
                int limit = 5;

                logger.DebugFormat("current num: {0}, limit: {1}", currentNum, limit);

                if (currentNum > limit)
                {
                    logger.DebugFormat("currnet num > {0}", limit);
                }
            };
            //將delegate實體加入至Class中同型別的delegate Field中
            counting.notifyHandler += del;            
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            logger.Debug("Action");
            CountingAction counting = new CountingAction();

            //使用Action<int>這個delegate型別建立新的Action<int>實體, 並將參考指向匿名方法
            //Action<int>代表此delegate傳入一個int參數, 沒有回傳值
            Action<int> del = (int currentNum) =>
            {
                int limit = 5;

                logger.DebugFormat("current num: {0}, limit: {1}", currentNum, limit);

                if (currentNum > limit)
                {
                    logger.DebugFormat("currnet num > {0}", limit);
                }
            };
            //將Action<int>實體加入至Class中同型別的Action Field中
            counting.notifyHandler += del;

            //可省略傳入參數類型, 若只有一行可省略大括號
            Action<int> del2 = (currnetNum) => logger.Debug(currnetNum * 10);
            counting.notifyHandler += del2;

            //若只有一個傳入參數可再省略括號
            Action<int> del3 = currnetNum => logger.Debug(currnetNum * 100);
            counting.notifyHandler += del3;

            //不使用變數直接加入Action
            counting.notifyHandler += currnetNum => logger.Debug(currnetNum * 1000);            
        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            //Action代表此委派無傳入參數, 也無回傳值
            Action action = () => logger.Debug(DateTime.Now);
            action();            
            
            //Action<int, int>代表此委派傳入兩個int參數, 無回傳值
            Action<int, int> action2 = (int1, int2) => logger.Debug(int1 + int2);
            action2(5, 10);

            string result;            

            //Func<int, int>代表此委派傳入兩個int參數, 回傳string
            Func<int, int, string> func = (int int1, int int2) =>
            {
                return (int1 + int2).ToString();
            };

            result = func(3, 5);
            logger.Debug(result);

            //省略傳入參數型別
            Func<int, int, string> func2 = (int1, int2) => { return (int1 + int2).ToString(); };

            result = func2(3, 5);
            logger.Debug(result);

            //如果只有一行可省略return及大括號
            Func<int, int, string> func3 = (int1, int2) => (int1 + int2).ToString();

            result = func3(3, 5);
            logger.Debug(result);
        }

        private void btnExpression_Click(object sender, EventArgs e)
        {                       
            using (NorthwindEntities db = new NorthwindEntities())
            {
                Func<Products, string> del = p => p.ProductName;
                db.Products.Select(del);

                Expression<Func<Products, string>> exp = p => p.ProductName;
                db.Products.Select(exp);

                Func<Products, string> del2 = exp.Compile();
                db.Products.Select(del2);
            }
        }

        #endregion


        #region 範例區

        private void btnSelect_Click(object sender, EventArgs e)
        {            
            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {
                GenericRepository<Products> productRepo = uof.Repository<Products>();
                GenericRepository<Categories> cateRepo = uof.Repository<Categories>();
                
                //取得所有product()
                List<Products> productList = productRepo.GetAll().ToList();

                //lambda查詢, 以特定條件取得, 第2頁, 每頁5筆
                productList = productRepo.Get(p => p.CategoryID == 1,
                                              q => q.OrderBy(p => p.ProductID).ThenBy(p => p.UnitPrice),
                                              null,
                                              2, 5).ToList();

                //以linq(query查詢)
                productList = (from p in productRepo.GetAll()
                               where p.Discontinued == false
                               select p).ToList();

                //以linq inner join(query查詢產生匿名型別)
                var resultList = (from p in productRepo.GetAll()
                                  join c in cateRepo.GetAll() on p.CategoryID equals c.CategoryID
                                  where p.Discontinued == false
                                  select new
                                  {
                                      ProductName = p.ProductName,
                                      CategoryName = c.CategoryName
                                  }).ToList();

                //以linq left join(query查詢產生匿名型別)
                resultList = (from p in productRepo.GetAll()
                              join c in cateRepo.GetAll() on p.CategoryID equals c.CategoryID into fg
                              from f in fg.DefaultIfEmpty()
                              where p.Discontinued == false
                              select new
                              {
                                  ProductName = p.ProductName,
                                  CategoryName = f.CategoryName
                              }).ToList();

                //以pk取得entity
                productList.Add(productRepo.Find(1));

                //以只有pk值的entity取得完整entity
                Products p2 = new Products();
                p2.ProductID = 2;
                productList.Add(productRepo.Find(p2));

                //跳過DbContext直接從資料庫取得Entity
                Products p3 = new Products();
                p3.ProductID = 30;
                productList.Add(productRepo.Load(p3));

                //以sql回傳Entity List
                productList = productRepo.GetBySql("select * from products where productid = @p0", 50).ToList();

                //以自訂Class為sql查詢結果
                List<ProductViewModel> decVMList = uof.SqlQuery<ProductViewModel>(
                                                            @"select ProductId, ProductName 
                                                                from products t1 
                                                                left join categories t2 on t1.categoryid = t2.categoryid 
                                                                where t1.productid = @productid",
                                                            new SqlParameter("@productid", 50))
                                                            .ToList();

                DataGridView1.DataSource = resultList;
            }
        }

        private void btnEagerLoadingAPI_Click(object sender, EventArgs e)
        {
            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {
                GenericRepository<Categories> repo = uof.Repository<Categories>();

                logger.Debug("lazy loading");
                //僅取得指定Entity
                Categories cateLazy = repo.GetAll().First();
                //於需要巡覽導覽屬性時, 才會產生sql去資料庫查詢
                foreach (var product in cateLazy.Products)
                {

                }

                logger.Debug("eager loading");
                //取得指定Entity, 並明確指定include導覽屬性
                List<Expression<Func<Categories, object>>> include = new List<Expression<Func<Categories, object>>>();
                include.Add(c => c.Products);
                Categories cateEager = repo.GetAll(include).First();
                //於需要巡覽導覽屬性時, 不會產生額外的sql查詢
                foreach (var product in cateEager.Products)
                {

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //已追蹤的物件, 先select再update
            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {
                GenericRepository<Products> productRepo = uof.Repository<Products>();

                //更新單筆
                Products p = productRepo.GetAll().FirstOrDefault();
                p.ProductName = DateTime.Now.ToString("yyyy-MM-dd");
                uof.SaveChanges();

                //更新多筆
                List<Products> productList = productRepo.GetAll().Take(5).ToList();
                foreach (Products item in productList)
                {
                    item.ProductName = DateTime.Now.ToString("yyyy-MM-dd");
                }

                //取得受影響筆數
                int rowAffected = uof.SaveChanges();

                logger.DebugFormat("row affected: {0}", rowAffected.ToString());
            }

            //未追蹤的物件, 直接初始化實體並更新
            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {
                Order_Details oDetail = new Order_Details();
                oDetail.OrderID = 10248;
                oDetail.ProductID = 11;
                oDetail.UnitPrice = 2;
                oDetail.Quantity = Convert.ToInt32(new Random().NextDouble() * 1000);
                //沒有給予值的話欄位會變成NULL
                //oDetail.Discount = Convert.ToInt32(new Random().NextDouble() * 10);
                
                //若不確定是否存在可使用AddOrUpdate
                uof.Repository<Order_Details>().AddOrUpdate(oDetail);
                uof.SaveChanges();
            }

            //以Transaction控制, 附帶catch DbEntityValidationException範例
            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {
                GenericRepository<Region> regRepo = uof.Repository<Region>();
                GenericRepository<Users> userRepo = uof.Repository<Users>();

                Region region = regRepo.GetAll().FirstOrDefault();
                Users user = userRepo.GetAll().FirstOrDefault();


                try
                {
                    uof.BeginTransaction();
                    region.RegionDescription = DateTime.Now.ToString("yyyy-MM-dd");
                    uof.SaveChanges();

                    user.Password = "會超過長度的長字串會超過長度的長字串會超過長度的長字串會超過長度的長字串會超過長度的長字串會超過長度的長字串會超過長度的長字串會超過長度的長字串";
                    uof.SaveChanges();

                    uof.Commit();
                }
                catch (DbEntityValidationException dbEx)
                {
                    logger.Error(dbEx.ToTraceString(), dbEx);

                    uof.Rollback();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);

                    uof.Rollback();

                }

            }

            //以TransactionScope控制跨多個連線的操作
            using (TransactionScope tran = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
                    {

                        Region region = uof.Repository<Region>().GetAll().FirstOrDefault();
                        region.RegionDescription = DateTime.Now.ToString("yyyy-MM-dd");
                        uof.SaveChanges();
                    }

                    using (UnitOfWork anotherUof = new UnitOfWork(new NorthwindEntities()))
                    {

                        Users user = anotherUof.Repository<Users>().GetAll().FirstOrDefault();
                        user.Password = "會超過長度的長字串會超過長度的長字串會超過長度的長字串會超過長度的長字串會超過長度的長字串會超過長度的長字串會超過長度的長字串會超過長度的長字串";
                        anotherUof.SaveChanges();
                    }

                    tran.Complete();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {
                //刪除單筆
                GenericRepository<Order_Details> repo = uof.Repository<Order_Details>();
                Order_Details detail = repo.GetAll().FirstOrDefault();
                repo.Remove(detail);
                uof.SaveChanges();

                //刪除多筆
                repo.RemoveMany(repo.GetAll().Take(3).ToList());
                uof.SaveChanges();

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {

                GenericRepository<Orders> repo = uof.Repository<Orders>();
                Orders order = new Orders();
                order.CustomerID = "VINET";

                repo.AddOrUpdate(order);

                uof.SaveChanges();

                //取得新的自動編號
                logger.DebugFormat("new Id: {0}", order.OrderID);

            }
        }

        private void btnFunction_Click(object sender, EventArgs e)
        {
            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {
                //呼叫純量值函數
                var query = (from emp in uof.Repository<Employees>().GetAll()
                             where NorthwindDbFunctions.fn_retEmployeeName(emp.EmployeeID) == "Leverling Janet"
                             select new
                             {
                                 EmployeeId = emp.EmployeeID,
                                 NameFirstChar = DbFunctions.Left(emp.FirstName, 1),
                                 DbTime = SqlFunctions.GetDate()
                             }).ToList();                

                DataGridView1.DataSource = query;
            }
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            using (NorthwindEntities db = new NorthwindEntities())
            {
                //呼叫Store Procedure
                var result = (from r in db.CustOrdersOrders("BERGS")
                              select r).ToList();

                DataGridView1.DataSource = result;

            }
        }

        private void btnAutoMapper_Click(object sender, EventArgs e)
        {
            List<Products> productList = new List<Products>();

            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {
                productList = uof.Repository<Products>().GetAll().Where(p => p.Categories != null && p.Suppliers != null).ToList();

                ////使用select方法, 需要逐一指定欄位
                //List<ProductViewModel> vmList = productList.Select(d => new ProductViewModel()
                //{
                //    ProductName = d.ProductName,
                //    CategoryName = d.Categories.CategoryName
                //}).ToList();

                ////使用AutoMapper, 欄位型別及名稱有對上就會自動mapping
                //Mapper.CreateMap<Products, ProductViewModel>();
                //List<ProductViewModel> vmList2 = Mapper.Map<List<ProductViewModel>>(productList);

                ////使用AutoMapper, 並指定要忽略的欄位及特殊處理欄位
                //Mapper.CreateMap<Products, ProductViewModel>()
                //      .ForMember(x => x.ReorderLevel, y => y.Ignore())
                //      .ForMember(x => x.SupplierName, y => y.MapFrom(s => string.Format("{0}-{1}", s.Suppliers.Country, s.Suppliers.CompanyName)));

                //List<ProductViewModel> vmList3 = Mapper.Map<List<ProductViewModel>>(productList);


                //使用initial方式於程式啟動時呼叫, 就不用每次都要先宣告
                Mapper.Initialize(c => c.AddProfile<ProductProfile>());
                List<ProductViewModel> vmList4 = Mapper.Map<List<ProductViewModel>>(productList);
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {            
            for (int i = 1; i <= 4000; i++)
            {
                logger.Debug(i);
            }
        }        

        private void btnLogHelper_Click(object sender, EventArgs e)
        {
            DummyService dummy = new DummyService();

            //呼叫無參數method
            LogHelper.Excute(() => dummy.DoSomething());

            //呼叫有參數method
            LogHelper.Excute(() => dummy.DoSomethingWithArgs(123));

            //呼叫複雜型別參數method
            ProductViewModel vm = new ProductViewModel {  ProductName = "product name" };
            LogHelper.Excute(() => dummy.DoSomethingWithComplexArgs(vm));

            //使用TryExecute並判斷結果是否成功
            ExecutedResult<ProductViewModel> result = LogHelper.TryExcute<ProductViewModel>(() => dummy.BadPerformanceMethod("myId", "TWD", "myName"));
            if (result.IsSuccess)
            {
                logger.DebugFormat("IsSuccess: {0}, ProductName: {1}", result.IsSuccess, result.Result.ProductName);
            }
            else
            {
                logger.Debug("execute failed");
            }

            //使用TryExecute並判斷結果是否成功
            ExecutedResult<ProductViewModel> result2 = LogHelper.TryExcute<ProductViewModel>(() => dummy.FailedMethod("myId", "TWD", "myName"));
            if (result2.IsSuccess)
            {
                logger.DebugFormat("IsSuccess: {0}, ProductName: {1}", result.IsSuccess, result.Result.ProductName);
            }
            else
            {
                logger.Debug("execute failed");
            }                                  
        }

        private void btnMsgBox_Click(object sender, EventArgs e)
        {
            //寫info log並跳出訊息視窗
            logger.InfoWithShowMsg(DateTime.Now.ToString());

            //寫warn log並跳出訊息視窗
            logger.WarnWithShowMsg(DateTime.Now.ToString());

            //寫error log並跳出訊息視窗
            logger.ErrorWithShowMsg(DateTime.Now.ToString());

            //寫fatal log並跳出訊息視窗
            Exception ex=  new Exception("new custom exception");
            logger.FatalWithShowMsg(ex.Message, ex);
        }

        private void btnBulkInsert_Click(object sender, EventArgs e)
        {
            List<Suppliers> list = new List<Suppliers>();
            for (int i = 1; i < 2000; i++)
            {
                list.Add(new Suppliers { CompanyName = i.ToString() });
            }

            logger.Info("start insert");
            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {
                uof.Repository<Suppliers>().AddMany(list);
                uof.SaveChanges();
            }
            logger.Info("end insert");

            logger.Info("start bulk insert");
            using (UnitOfWork uof = new UnitOfWork(new NorthwindEntities()))
            {
                uof.Repository<Suppliers>().BulkInsert(list);
            }
            logger.Info("end bulk insert");
        }

        #endregion                          
    }

}
