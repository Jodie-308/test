using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Manage 的摘要说明
/// </summary>
public class Manage
{
    public Manage()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //

    }
    public string CheckUser(string uname, string upwd)
    {
        string ulevel = "NoExist";
        string path = System.Web.HttpContext.Current.Server.MapPath("Data/Data.txt");
        StreamReader sr = new StreamReader(path, Encoding.GetEncoding("gb2312"));
        while (!sr.EndOfStream)
        {
            string name = sr.ReadLine();
            string pwd = sr.ReadLine();
            string level = sr.ReadLine();
            if (uname == name && upwd == pwd)
            {
                ulevel = level;
            }
        }
        sr.Close();
        return ulevel;
    }

    private bool CheckUser(string uname)//CheckUser方法的重载
    {
        bool exist = false;
        string path = System.Web.HttpContext.Current.Server.MapPath("Data/Data.txt");
        StreamReader sr = new StreamReader(path, Encoding.GetEncoding("gb2312"));
        while (!sr.EndOfStream)
        {
            string name = sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();
            if (uname == name)
            {
                exist = true;
            }
        }
        sr.Close();
        return exist;
    }

    public string AddUser(string uname, string upwd)
    {
        if (CheckUser(uname))
        {
            return "用户名已存在";
        }

        try
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("Data/Data.txt");
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            sw.WriteLine(uname);
            sw.WriteLine(upwd);
            sw.WriteLine("user");
            sw.Close();
            fs.Close();
            return "注册成功，请登录";
        }
        catch
        {
            return "注册失败";
        }
    }
    public string AddVIP(string uname, string upwd)
    {
        if (CheckUser(uname))
        {
            return "用户名已存在";
        }

        try
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("Data/Data.txt");
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("gb2312"));
            sw.WriteLine(uname);
            sw.WriteLine(upwd);
            sw.WriteLine("VIPuser");
            sw.Close();
            fs.Close();
            return "注册成功，请登录";
        }
        catch
        {
            return "注册失败";
        }
    }
}