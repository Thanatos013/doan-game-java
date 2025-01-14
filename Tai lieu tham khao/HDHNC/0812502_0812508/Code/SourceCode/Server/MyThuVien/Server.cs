using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using MyFile;
using MyUser;
using System.Threading;
using System.Data.OleDb;

namespace MyThuVien
{
    public class Server
    {
        public  static List<File> m_arrDanhSachFile;
        public  static List<User> m_arrDanhSachUser;
        public static Mutex ms;
        public Socket m_socServer;
        public  int m_iPort,m_iSoClient;
        public  Socket[] m_socLamViec;
        //Ham doc Co So Du Lieu
        public static OleDbConnection KetNoi()
        {
            String chuoiKetNoi = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CSDL.mdb";
            OleDbConnection ketNoi = new OleDbConnection(chuoiKetNoi);
            ketNoi.Open();
            return ketNoi;
        }
        //Cac ham thao tac voi co so du lieu
        public static List<User> LayDanhSachUser()
        {
            OleDbConnection ketNoi = null;
            List<User> ds_User = new List<User>();
            try
            {
                ketNoi = KetNoi();
                string chuoiLenh = "select TenUser, PassWord, Port, Ip from TableUser";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, ketNoi);
                OleDbDataReader boDoc = lenh.ExecuteReader();
                while (boDoc.Read())
                {
                    User tam = new User();
                    if (!boDoc.IsDBNull(0))
                        tam.m_sTenUser = boDoc.GetString(0);
                    if (!boDoc.IsDBNull(1))
                        tam.m_sPassword = boDoc.GetString(1);
                    if (!boDoc.IsDBNull(2))
                        tam.m_iPort = boDoc.GetInt16(2);
                    if (!boDoc.IsDBNull(3))
                        tam.m_IpAddress =IPAddress.Parse(  boDoc.GetString(3));
                    ds_User.Add(tam);
                }
            }
            catch
            {
                ds_User = new List<User>();
            }
            finally
            {
                if (ketNoi != null && ketNoi.State == System.Data.ConnectionState.Open)
                    ketNoi.Close();
            }
            return ds_User;
        }

        public static List<File> layDanhSachFile()
        {
            OleDbConnection ketNoi = null;
            List<File> ds_File = new List<File>();
            try
            {
                ketNoi = KetNoi();
                string chuoiLenh = "SELECT TenFile,TenUserGiu "
                                    + "FROM TableFile  ";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, ketNoi);
                OleDbDataReader boDoc = lenh.ExecuteReader();
                while (boDoc.Read())
                {
                    File tam = new File();
                    if (!boDoc.IsDBNull(0))
                        tam.m_sTenFile = boDoc.GetString(0);
                    if (!boDoc.IsDBNull(1))
                        tam.m_sUserGiuFile = boDoc.GetString(1);
                    ds_File.Add(tam);
                }
            }
            catch
            {
                ds_File = new List<File>();
            }
            finally
            {
                if (ketNoi != null && ketNoi.State == System.Data.ConnectionState.Open)
                    ketNoi.Close();
            }
            return ds_File;
        }

        public static bool themUserMoi(User UserNew)
        {

            bool ketQua = true;
            OleDbConnection ketNoi = null;
            try
            {
                ketNoi = KetNoi();
                string chuoiLenh = "INSERT INTO TableUser VALUES(@TenUser, @PassWord, @Port, @Ip)";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, ketNoi);

                // Các tham số
                // Thứ tự các tham số trong chuoiLenh và thứ tự add các tham số phải giống nhau
                OleDbParameter thamSo;
                thamSo = new OleDbParameter("@TenUser", OleDbType.VarChar);
                thamSo.Value = UserNew.m_sTenUser;
                lenh.Parameters.Add(thamSo);

                thamSo = new OleDbParameter("@PassWord", OleDbType.VarChar);
                thamSo.Value = UserNew.m_sPassword;
                lenh.Parameters.Add(thamSo);

                thamSo = new OleDbParameter("@Port", OleDbType.Integer);
                thamSo.Value = UserNew.m_iPort;
                lenh.Parameters.Add(thamSo);

                 thamSo = new OleDbParameter("@Ip", OleDbType.VarChar);
                thamSo.Value = UserNew.m_IpAddress;
                lenh.Parameters.Add(thamSo); 

                lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ketQua = false;
            }
            finally
            {
                if (ketNoi != null && ketNoi.State == System.Data.ConnectionState.Open)
                    ketNoi.Close();
            }
            return ketQua;
        }

        public static bool themFileTrenCoSoDuLieu(File FileNew)
        {
            bool ketQua = true;
            OleDbConnection ketNoi = null;
            try
            {
                ketNoi = KetNoi();
                string chuoiLenh = "INSERT INTO TableFile( TenFile, TenUserGiu) VALUES( @TenFile, @TenUserGiu)";
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, ketNoi);
                OleDbParameter thamSo = new OleDbParameter("@TenFile", OleDbType.VarChar);
                thamSo.Value = FileNew.m_sTenFile;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@TenUserGiu", OleDbType.VarChar);
                thamSo.Value = FileNew.m_sUserGiuFile;
                lenh.Parameters.Add(thamSo);
                lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ketQua = false;
            }
            finally
            {
                if (ketNoi != null && ketNoi.State == System.Data.ConnectionState.Open)
                    ketNoi.Close();
            }
            return ketQua;
        }

        public static bool xoaFileTrenCoSoDuLieu(string User, string File)
        {
            bool ketQua = true;
            OleDbConnection ketNoi = null;
            try
            {
                ketNoi = KetNoi();
                string chuoiLenh = "Delete from TableFile where TenFile=@TenFile and TenUserGiu=@TenUserGiu "; 
                OleDbCommand lenh = new OleDbCommand(chuoiLenh, ketNoi);
                OleDbParameter thamSo = new OleDbParameter("@TenFile", OleDbType.VarChar);
                thamSo.Value = File;
                lenh.Parameters.Add(thamSo);
                thamSo = new OleDbParameter("@TenUserGiu", OleDbType.VarChar);
                thamSo.Value = User;
                lenh.Parameters.Add(thamSo);
                lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ketQua = false;
            }
            finally
            {
                if (ketNoi != null && ketNoi.State == System.Data.ConnectionState.Open)
                    ketNoi.Close();
            }
            return ketQua;
        

        }
        
        
        //Ham dung cua server
        public Server()
        {
            m_socServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_iSoClient = 0;
            m_socLamViec = new Socket[200];
            ms = new Mutex();
            m_arrDanhSachFile = new List<File>();
            // lay danh sach file tu trong co so du lieu
            m_arrDanhSachFile = layDanhSachFile();

            m_arrDanhSachUser = new List<User>();
            // lay danh sach user tu trong co so du lieu
            m_arrDanhSachUser = LayDanhSachUser();

            User thuan = new User();
            thuan.m_IpAddress = IPAddress.Parse("127.0.0.1");
            thuan.m_iPort = 8800;
            thuan.m_sPassword = "123";
            thuan.m_sTenUser = "thuan";

            m_arrDanhSachUser.Add(thuan);

            User thong = new User();
            thong.m_IpAddress = IPAddress.Parse("127.0.0.1");
            thong.m_iPort = 8899;
            thong.m_sPassword = "123";
            thong.m_sTenUser = "thong";

            m_arrDanhSachUser.Add(thong);


            
            
                  
        }

        public void LangNghe()
        {
            try
            {
               
                IPEndPoint ipLocal = new IPEndPoint(System.Net.IPAddress.Any, m_iPort);
                //bind to local IP Address...
                m_socServer.Bind(ipLocal);
                //start listening...
                m_socServer.Listen(200);
                // create the call back for any client connections...
                m_socServer.BeginAccept(new AsyncCallback(ClientKetNoi), null);
            }
            catch
            {
                m_socServer.Close();
            }
        }
        public void ClientKetNoi(IAsyncResult asyn)
        {

                ThreadStart myThreadDelegate = new ThreadStart(LamViec);
                try
                {
                    m_socLamViec[m_iSoClient] = m_socServer.EndAccept(asyn);
                }
                catch (Exception ex1)
                {
                    
                    m_socServer.Close();
                }
                Thread myThread = new Thread(myThreadDelegate);
            try
            {

                myThread.Start();              
                m_socServer.BeginAccept(new AsyncCallback(ClientKetNoi), null);
            }
            catch(Exception ex)
            {
                myThread.Abort();
            }
        }
        public  void LamViec()
        {
         
            Socket m_socTam = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                m_socTam = m_socLamViec[m_iSoClient];
                m_iSoClient++;


                while (true)
                {

                    byte[] data = new byte[1024];
                    int recv = m_socTam.Receive(data);
                    string s = Encoding.ASCII.GetString(data, 0, recv);
                    string kq = PhanTichGoiTin(s, m_socTam);
                    if (kq != "khong send")
                    {
                        byte[] send = new byte[1024];
                        send = Encoding.ASCII.GetBytes(kq);
                        m_socTam.Send(send, send.Length, SocketFlags.None);
                        if (kq.Contains("da online") == true)
                        {
                           
                                string[] arr;
                                arr = kq.Split(new char[] { '-' });
                                string thongbao = arr[1];
                                string userGiu = arr[0];
                                try
                                {
                                    Thread t = new Thread(DownOffline);
                                    //object name=(object)userGiu;
                                    t.Start(userGiu);
                                }
                                catch (Exception ex)
                                {
                                    Thread.Sleep(1);
                                }
                            
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                
                Thread.Sleep(1);
            } 
        }

        //co truy xuat tai nguyen dung chung
        public  string DangNhap(string s,Socket soc)
        {
            string username;
            string password;
            string port;
            int i;
            string[] arr;
            arr = s.Split(new char[] { '-' });
            username = arr[0];
            password = arr[1];
            port = arr[2];
            IPAddress ip = IPAddress.Parse(((IPEndPoint)soc.RemoteEndPoint).Address.ToString());

            for (i = 0; i < m_arrDanhSachUser.Count; i++)
            {
                if (m_arrDanhSachUser[i].m_sTenUser == username)
                {
                    if (password == m_arrDanhSachUser[i].m_sPassword)
                    {
                        if (int.Parse(port) == m_arrDanhSachUser[i].m_iPort)
                        {
                            if (ip.ToString() == m_arrDanhSachUser[i].m_IpAddress.ToString())
                            {
                                ms.WaitOne();
                                // mien dung do
                                for (int j = 0; j < m_arrDanhSachFile.Count; j++)
                                {
                                    if (m_arrDanhSachFile[j].m_sUserGiuFile == username)
                                        m_arrDanhSachFile[j].m_bTinhTrangUser = "online";
                                }
                                //mien dung do
                                ms.ReleaseMutex();
                                return "dang nhap thanh cong";
                            }
                            else
                                return "Khong dung ip luc dang ky.Moi ban dang ky lai hoac chuyen may";
                        }
                        else
                            return "nhap sai port da dang ki";
                    }
                    else
                        return "nhap sai password";
                }
            }
            return "nhap sai user hoac user chua dang ky";
        }

        //co truy xuat tai nguyen dung chung
       public  List<File> TimKiemFile(string s)
        {
            List<File> kq = new List<File>();
            string tenfile;
            string username;
            int i;
            string[] arr;
            arr = s.Split(new char[] { '-' });
            username = arr[1];
            tenfile = arr[0];
            ms.WaitOne();
           //mien dung do
            for (i = 0; i <m_arrDanhSachFile.Count; i++)
            {
                if (m_arrDanhSachFile[i].m_sTenFile.Contains(tenfile))
                {                   
                        kq.Add( m_arrDanhSachFile[i]);                 
                }

            }
           //mien dung do
            ms.ReleaseMutex();
           return kq;
        }

        public  string GuiTraLoiChoUser(List<File> s)
        {
            if (s.Count==0)
                return "khong tim thay file";
            else
            {
                string kq = "",tam;
                for (int i = 0; i < s.Count; i++)
                {

                    tam = kq;
                    kq =tam+ s[i].m_sTenFile + "-" + s[i].m_sUserGiuFile + "-" + s[i].m_bTinhTrangDownLoad + "-" + s[i].m_bTinhTrangUser+ "-";
                }
                return kq;
            }
        }

        public  string DangKy(string s,Socket soc)
        {
            User kq = new User();
            string username;
            string password1;
            string password2;
            string port;          
            string[] arr;
            arr = s.Split(new char[] { '-' });
            username = arr[0];
            password1 = arr[1];
            password2 = arr[2];
            port = arr[3];

            
            int i = string.Compare(password1, password2,false);
            if (i != 0)
                return "Password nhap sai";
            else
            {
               
                kq.LayThongTin(username, password1, ((IPEndPoint)soc.RemoteEndPoint).Address.ToString(), int.Parse(port));
                m_arrDanhSachUser.Add(kq);
                themUserMoi(kq);
                return "Dang Ky Thanh Cong,Moi dang nhap lai";
            }

        }
       
        //co truy xuat tai nguyen dung chung
        public  string  DangXuat(string s,Socket soc)
        {
            int i;
            
            ms.WaitOne();
            //mien dung do
            for (i = 0; i < m_arrDanhSachFile.Count; i++)
            {
                if (m_arrDanhSachFile[i].m_sUserGiuFile == s)
                {                    
                    m_arrDanhSachFile[i].m_bTinhTrangUser = "offline";
                }
            }
            //mien dung do
            ms.ReleaseMutex();
            soc.Close();
            return "khong send";
        }                

        
        public  string NhanFile(string s)
        {
            string filename, username;
            File file = new File();
            string[] arr;
            arr = s.Split(new char[] { '-' });
            filename = arr[0];
            username = arr[1];

            for (int e = 0; e < m_arrDanhSachFile.Count; e++)
                if (m_arrDanhSachFile[e].m_sTenFile == filename && m_arrDanhSachFile[e].m_sUserGiuFile == username)
                    return "file da duoc ban chia se roi hoac trung ten";

            file.m_sTenFile = filename;
            file.m_sUserGiuFile = username;
            file.m_bTinhTrangUser = "online";
            file.m_bTinhTrangDownLoad = "khong";
            m_arrDanhSachFile.Add(file);
            themFileTrenCoSoDuLieu(file);
            return "Nhan file thanh cong";
        }

        //co truy xuat tai nguyen dung chung
        public  string XoaFile(string s)
        {
            
            string[] arr;
            string filename, username;
            arr = s.Split(new char[] { '-' });
            filename = arr[0];
            username = arr[1];
            ms.WaitOne();
            //mien dung do
            for (int e = 0; e < m_arrDanhSachFile.Count; e++ )
            {
                if (m_arrDanhSachFile[e].m_sTenFile == filename && m_arrDanhSachFile[e].m_sUserGiuFile == username)
                {
                    m_arrDanhSachFile.Remove(m_arrDanhSachFile[e]);
                    xoaFileTrenCoSoDuLieu(username, filename);
                    ms.ReleaseMutex();
                    return "Da Xoa";
                }
            }
            //mien dung do
            
            return "khong tim thay file can xoa";

        }

        //co truy xuat tai nguyen dung chung
        public  string  NhanXong(string s)
        {
           // int i, j = 0;
            string filename;
            string username;
            string[] arr;
            arr = s.Split(new char[] { '-' });
            filename = arr[0];
            username = arr[1];
            User userGiu = new User();
            ms.WaitOne();
            //mien dung do
            for (int e = 0; e < m_arrDanhSachFile.Count; e++)
            {
                if (m_arrDanhSachFile[e].m_sTenFile == filename && m_arrDanhSachFile[e].m_sUserGiuFile == username)
                {

                    if (m_arrDanhSachFile[e].HangDoiDownLoad.Count != 0)
                    {
                        string userDown = m_arrDanhSachFile[e].HangDoiDownLoad.Dequeue();
                        for (int j = 0; j < m_arrDanhSachUser.Count; j++)
                        {
                            if (m_arrDanhSachUser[j].m_sTenUser == username)
                                userGiu = m_arrDanhSachUser[j];
                            if (m_arrDanhSachUser[j].m_sTenUser == userDown)
                            {
                                Socket m_socTemp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                IPEndPoint IPEnd = new IPEndPoint(m_arrDanhSachUser[j].m_IpAddress, m_arrDanhSachUser[e].m_iPort);
                                m_socTemp.Connect(IPEnd);
                                string chuoi = filename + "-" + userGiu.m_sTenUser + "-" + userGiu.m_IpAddress.ToString() + "-" + userGiu.m_iPort.ToString();
                                byte[] data = new byte[1024];
                                data = Encoding.ASCII.GetBytes(chuoi);
                                m_socTemp.Send(data, data.Length, SocketFlags.None);
                                m_socTemp.Close();
                            }
                        }
                        ms.ReleaseMutex();
                        return "Xac nhan da upload xong " + filename;
                    }
                    else
                    {
                        ms.ReleaseMutex();
                        return "Xac nhan da upload xong " + filename;
                    }
                }
              
            }
            //mien dung do
            
            return " Khong the xac nhan da down load xong";
        }
      
        public  string PhanTichGoiTin(string s,Socket soc)
        {
            int  flag;
            string kq = "";
            string temp = s.Substring(2);

           flag = int.Parse(s[0].ToString());

            switch (flag)
            {
                case 1: kq = DangNhap(temp,soc); break;
                case 2:
                    {
                        List<File> tam=new List<File>();
                        tam = TimKiemFile(temp);
                        kq = GuiTraLoiChoUser(tam);
                        break;
                    }
                case 3: kq = DangKy(temp,soc); break;
                case 4: kq = DangXuat(temp,soc); break;
                case 5: kq = NhanFile(temp); break;
                case 6: kq = XoaFile(temp); break;
                case 7: kq = NhanXong(temp); break;
                case 8:
                    {
                        string filename;
                        string userGiu;
                        MyUser.User userDown = new User();
                        string kq1;
                        kq1 = "1-user nay khong giu file nay";
                        int i, dem = 0;
                        string[] arr;
                        arr = temp.Split(new char[] { '-' });
                        filename = arr[0];
                        userGiu = arr[1];
                        userDown.m_sTenUser = arr[2];
                        for (i = 0; i < m_arrDanhSachUser.Count; i++)
                            if (m_arrDanhSachUser[i].m_sTenUser == userDown.m_sTenUser)
                                userDown = m_arrDanhSachUser[i];
                        if (userDown.m_sTenUser == userGiu)
                        {
                            kq1 = "1-user muon down dang giu file nay";
                            Socket tam = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            IPEndPoint iplocal = new IPEndPoint(userDown.m_IpAddress, userDown.m_iPort);

                            tam.Connect(iplocal);
                            byte[] send = new byte[1024];
                            send = Encoding.ASCII.GetBytes(kq1);
                            tam.Send(send, send.Length, SocketFlags.None);
                            tam.Close();
                            kq = "khong send";
                        }
                        else
                        {
                            for (i = 0; i < m_arrDanhSachFile.Count; i++)
                            {
                                if (m_arrDanhSachFile[i].m_sTenFile == filename && m_arrDanhSachFile[i].m_sUserGiuFile == userGiu)
                                {
                                    if (m_arrDanhSachFile[i].m_bTinhTrangUser == "offline")
                                    {
                                        kq1 = "1-User giu file khong online";
                                        m_arrDanhSachFile[i].HangDoiDownLoad.Enqueue(userDown.m_sTenUser);
                                    }
                                    else
                                        if (m_arrDanhSachFile[i].m_bTinhTrangDownLoad == "co")
                                        {
                                            //dua ten user giu vao hang doi cua file do
                                            m_arrDanhSachFile[i].HangDoiDownLoad.Enqueue(userDown.m_sTenUser);
                                            kq1 = "1-vui long doi";
                                        }
                                        else
                                        {
                                            for (int e = 0; e < m_arrDanhSachUser.Count; e++)
                                            {
                                                if (m_arrDanhSachUser[e].m_sTenUser == userGiu)
                                                {
                                                    kq1 = "2-" + filename + "-" + m_arrDanhSachUser[e].m_sTenUser + "-" + m_arrDanhSachUser[e].m_IpAddress.ToString() + "-" + m_arrDanhSachUser[e].m_iPort.ToString();

                                                }
                                            }
                                        }
                                }
                                else
                                    dem++;

                            }
                            if (dem == m_arrDanhSachFile.Count)
                                kq1 = "1-khong tim thay file can down hoac file do da bi xoa";

                            Socket tam = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            IPEndPoint iplocal = new IPEndPoint(userDown.m_IpAddress, userDown.m_iPort);

                            tam.Connect(iplocal);
                            byte[] send = new byte[1024];
                            send = Encoding.ASCII.GetBytes(kq1);
                            tam.Send(send, send.Length, SocketFlags.None);
                            tam.Close();
                            kq = "khong send";
                        }
                    } break;
                case 9: kq = temp; break;
            }
            return kq;
        }

        public void DownOffline(object name)
        {
            string userGiu = (string)name;
            User Giu=new User();
            for (int j = 0; j < m_arrDanhSachUser.Count; j++)
            {
                if (m_arrDanhSachUser[j].m_sTenUser == userGiu)
                    Giu = m_arrDanhSachUser[j];
            }
                        for (int i = 0; i < m_arrDanhSachFile.Count; i++)
                        {
                            if (m_arrDanhSachFile[i].m_sUserGiuFile == userGiu)
                                if (m_arrDanhSachFile[i].HangDoiDownLoad.Count > 0)
                                {
                                    string send = "";
                                    //MyUser.User userDown=new User();
                                    string userDown = m_arrDanhSachFile[i].HangDoiDownLoad.Dequeue();
                                    for (int e = 0; e < m_arrDanhSachUser.Count; e++)
                                    {
                                        if (m_arrDanhSachUser[e].m_sTenUser == userDown)
                                        {
                                            send = "2-" + m_arrDanhSachFile[i].m_sTenFile + "-" + Giu.m_sTenUser + "-" + Giu.m_IpAddress.ToString() + "-" + Giu.m_iPort.ToString();
                                            try
                                            {
                                                Socket tam = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                                                IPEndPoint iplocal = new IPEndPoint(m_arrDanhSachUser[e].m_IpAddress, m_arrDanhSachUser[e].m_iPort);

                                                tam.Connect(iplocal);
                                                byte[] send1 = new byte[1024];
                                                send1 = Encoding.ASCII.GetBytes(send);
                                                tam.Send(send1, send1.Length, SocketFlags.None);
                                                tam.Close();
                                            }
                                            catch (Exception ex)
                                            {
                                                Thread.Sleep(1);
                                            }
                                            break;
                                        }
                                       
                                    }
                                }
                                /*else
                                {
                                    Thread.Sleep(1);
                                    return;
                                }*/
                        }
                        Thread.Sleep(1);
                        return;
                                      
         }         
               
    }
}
