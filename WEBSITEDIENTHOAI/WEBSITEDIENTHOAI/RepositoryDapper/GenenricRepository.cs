using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using WEBSITEDIENTHOAI.Models;

namespace WEBSITEDIENTHOAI.RepositoryDapper
{
    public interface IGenericRepository
    {
        T? Find<T>(int id);
        List<T> GetAll<T>();
        bool Add<T>(object Sanpham); 

        bool Update<T>(int id ,object Sanpham);
        void Remove<T>(int id);

    }
    public class GenenricRepository : IGenericRepository
    {
        private readonly IDbConnection db;

        public GenenricRepository(IConfiguration configuration)

        {

            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        }
        public bool Add<T>(object Sanpham)
        {
  
            switch (typeof(T).Name.ToString())
            {
                case "SANPHAM":
                    return BuildQuerySql((SANPHAM)Sanpham);
                case "CTSANPHAM":
                    return BuildQuerySql((CTSANPHAM)Sanpham);
                case "MAUSAC":
                    return BuildQuerySql((MAUSAC)Sanpham);
                case "GIOHANG":
                    return BuildQuerySql((GIOHANG)Sanpham);
                case "HOADON":
                    return BuildQuerySql((HOADON)Sanpham);
                case "CTHOADON":
                    return BuildQuerySql((CTHOADON)Sanpham);
            }
            return false;

        }
        private bool BuildQuerySql(SANPHAM model)
        {
            var sql = @"INSERT INTO SANPHAM VALUES(N'{0}',{1},{2})"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        model.Tensp,
                                        model.Sluong,
                                        model.Giasp
                                        );
            var result = db.Query<SANPHAM>(query).ToList();
            if (result != null) return true;
            return false;
        }


        private bool BuildQuerySql(CTSANPHAM cTSANPHAM)
        {
            var sql = @"INSERT INTO CTSANPHAM VALUES ({0}, N'{1}',N'{2}') "

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        cTSANPHAM.IDsanpham,
                                        cTSANPHAM.Tensp,
                                        cTSANPHAM.ThuongHieu
                                        );
            var result = db.Query<CTSANPHAM>(query).ToList();
            if (result != null) return true;
            return false;
        }

        private bool BuildQuerySql(MAUSAC model)
        {
            var sql = @"INSERT INTO MAUSAC VALUES(N'{0}',{1},{2})"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        model.Tenmausac,
                                        model.Soluong,
                                        model.IDctsanpham
                                        );
            var result = db.Query<MAUSAC>(query).ToList();
            if (result != null) return true;
            return false;
        }

        private bool BuildQuerySql(GIOHANG model)
        {
            var sql = @"INSERT INTO GIOHANG VALUES({0},'{1}',{2})"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        model.IDsanpham,
                                        model.Tensp,
                                        model.Sluongdat
                                        );
            var result = db.Query<GIOHANG>(query).ToList();
            if (result != null) return true;
            return false;
        }

        private bool BuildQuerySql(HOADON model)
        {
            var sql = @"INSERT INTO HOADON VALUES({0},{1},{2})"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        model.IDgiohang,
                                        model.Sluongdat,
                                        model.Tongdonhang
                                        );
            var result = db.Query<HOADON>(query).ToList();
            if (result != null) return true;
            return false;
        }

        private bool BuildQuerySql(CTHOADON model)
        {
            var sql = @"INSERT INTO CTHOADON VALUES({0},{1})"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        model.IDhoadon,
                                        model.Ngaythanhtoan
                                        );
            var result = db.Query<CTHOADON>(query).ToList();
            if (result != null) return true;
            return false;
        }
        public T? Find<T>(int id)
        {
            var sql = "SELECT * FROM {0} WHERE ID{1} = {2}";
            //typeof(T).Name.ToString().ToUpper() thay cho so 0
            //typeof(T).Name.ToString().ToLower() thay cho so 1
            //id thay cho so 2
            //VD: 0 is SANPHAM, 1 IS sanpham, 2 is id => SELECT * FROM SANPHAM WHERE IDsanpham = id
            var query = string.Format(sql
                , typeof(T).Name.ToString().ToUpper()
                , typeof(T).Name.ToString().ToLower()
                , id);
            return db.Query<T>(query).FirstOrDefault();
        }

        public List<T> GetAll<T>()
        {
            var sql = "SELECT * FROM {0}";
            var query = string.Format(sql, typeof(T).Name.ToString().ToUpper());
            return db.Query<T>(query).ToList();
        }

        public void Remove<T>(int id)
        {
            var sql = "DELETE DBO.{0} WHERE ID{1} = {2}";
            var query = string.Format(sql
                , typeof(T).Name.ToString().ToUpper()
                , typeof(T).Name.ToString().ToLower()
                , id);
            db.Query<T>(query).FirstOrDefault();
        }

      

        public bool Update<T>(int id, object Sanpham)
        {
            switch (typeof(T).Name.ToString())
            {
                case "SANPHAM":
                    return BuildQueryUpdateSP(id ,(SANPHAM)Sanpham);
                case "CTSANPHAM":
                    return BuildQueryUpdateSP(id, (CTSANPHAM) Sanpham);
                case "MAUSAC":
                    return BuildQueryUpdateSP(id, (MAUSAC)Sanpham);
                case "GIOHANG":
                    return BuildQueryUpdateSP(id, (GIOHANG)Sanpham);
                case "HOADON":
                    return BuildQueryUpdateSP(id, (HOADON)Sanpham);
                case "CTHOADON":
                    return BuildQueryUpdateSP(id, (CTHOADON)Sanpham);


            }
            return false;
        }
        private bool BuildQueryUpdateSP(int id, SANPHAM Sanpham)
        {
            var sql = @"UPDATE SANPHAM SET Tensp = '{0}', Sluong = '{1}', Giasp = '{2}' WHERE IDsanpham = {3}"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        Sanpham.Tensp,
                                        Sanpham.Sluong,
                                        Sanpham.Giasp,
                                        id
                                        );
            var result = db.Query<SANPHAM>(query).ToList();
            if (result != null) return true;
            return false;
        }
        private bool BuildQueryUpdateSP(int id, CTSANPHAM Sanpham)
        {
            var sql = @"UPDATE CTSANPHAM SET IDsanpham = {0}, Tensp = '{1}', ThuongHieu = '{2}' WHERE IDctsanpham = {3}"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        Sanpham.IDsanpham,
                                        Sanpham.Tensp,
                                        Sanpham.ThuongHieu,
                                        id
                                        );
            var result = db.Query<CTSANPHAM>(query).ToList();
            if (result != null) return true;
            return false;
        }
        private bool BuildQueryUpdateSP(int id, MAUSAC Sanpham)
        {
            var sql = @"UPDATE MAUSAC SET Tenmausac = '{0}', Soluong = {1}, IDctsanpham = {2} WHERE IDmausac = {3}"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        Sanpham.Tenmausac,
                                        Sanpham.Soluong,
                                        Sanpham.IDctsanpham,
                                        id
                                        );
            var result = db.Query<MAUSAC>(query).ToList();
            if (result != null) return true;
            return false;
        }
        private bool BuildQueryUpdateSP(int id, GIOHANG Sanpham)
        {
            var sql = @"UPDATE MAUSAC SET IDsanpham = {0}, Tensp = N'{1}', Sluongdat = {2} WHERE IDgiohang = {3}"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        Sanpham.IDsanpham,
                                        Sanpham.Tensp,
                                        Sanpham.Sluongdat,
                                        id
                                        );
            var result = db.Query<GIOHANG>(query).ToList();
            if (result != null) return true;
            return false;
        }
        private bool BuildQueryUpdateSP(int id, HOADON Sanpham)
        {
            var sql = @"UPDATE MAUSAC SET Sluongdat = {0}, Tongdonhang = {1}WHERE IDhoadon = {2}"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        Sanpham.Sluongdat,
                                        Sanpham.Tongdonhang,
                                        id
                                        );
            var result = db.Query<HOADON>(query).ToList();
            if (result != null) return true;
            return false;
        }
        private bool BuildQueryUpdateSP(int id, CTHOADON Sanpham)
        {
            var sql = @"UPDATE MAUSAC SET IDhoadon = {0}, Ngaythanhtoan = {1}, Noinhanhang = {2} WHERE IDcthoadon = {3}"

                        +

                        " SELECT CAST(SCOPE_IDENTITY() AS INT)";
            var query = string.Format(sql,
                                        Sanpham.IDhoadon,
                                        Sanpham.Ngaythanhtoan,
                                        Sanpham.Noinhanhang
                                        ,id
                                        );
            var result = db.Query<CTHOADON>(query).ToList();
            if (result != null) return true;
            return false;
        }

    }
}
