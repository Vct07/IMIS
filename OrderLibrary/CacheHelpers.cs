using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;

namespace BPElement
{
    /// <summary>
    /// 缓存操作
    /// </summary>
    public class CacheHelpers
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        /// <param name="fileName">依赖文件名或路径</param>
        public static void Add(string key, object value, string fileName, CacheItemPriority priority = CacheItemPriority.Normal)
        {
            CacheDependency dependency=new CacheDependency(fileName);
            HttpRuntime.Cache.Add(key, value, dependency, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, priority, null);
             
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        /// <param name="priority">缓存级别</param>
        /// <param name="cmd">数据库操作对象</param>
        public static void Add(string key,object value,SqlCommand cmd, CacheItemPriority priority = CacheItemPriority.Normal )
        {
            SqlCacheDependency dependency = new SqlCacheDependency(cmd);
            HttpRuntime.Cache.Add(key, value, dependency, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, priority, null);
        }


        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        /// <param name="cmd">数据库操作对象</param>
        /// <param name="outTime">绝对过期时间</param>
        /// <param name="priority">缓存级别</param>
        /// <param name="IsAbsolute">true：绝对过期  false：滑动过期</param>
        public static void Add(string key, object value, SqlCommand cmd,int time,bool IsAbsolute, CacheItemPriority priority = CacheItemPriority.Normal)
        {
            SqlCacheDependency dependency = new SqlCacheDependency(cmd);
            if(IsAbsolute)
                HttpRuntime.Cache.Add(key, value, dependency, DateTime.Now.AddSeconds(time), System.Web.Caching.Cache.NoSlidingExpiration, priority, null);
            else
                HttpRuntime.Cache.Add(key, value, dependency, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(time), priority, null);
        }


        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        public static void Add(string key, object value, CacheItemPriority priority = CacheItemPriority.Normal)
        {
            Add(key, value, 300,true, priority);
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        /// <param name="outtime">过期时间(秒)</param>
        /// <param name="IsAbsolute">true：绝对过期  false：滑动过期</param>
        public static void Add(string key, object value, int time,bool IsAbsolute, CacheItemPriority priority = CacheItemPriority.Normal)
        {
            if (IsAbsolute)
                HttpRuntime.Cache.Add(key, value, null, DateTime.Now.AddSeconds(time), System.Web.Caching.Cache.NoSlidingExpiration, priority, null);
            else
                HttpRuntime.Cache.Add(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(time), priority, null);
            
        }

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        public static void Insert(string key,object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        /// <param name="outTime">绝对过期时间</param>        
        /// <param name="IsAbsolute">true：绝对过期  false：滑动过期</param>
        public static void Insert(string key, object value, int time, bool IsAbsolute)
        {
            if (IsAbsolute)
                HttpRuntime.Cache.Insert(key, value, null, DateTime.Now.AddSeconds(time), System.Web.Caching.Cache.NoSlidingExpiration, null);
            else
                HttpRuntime.Cache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(time), null);
        }

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        /// <param name="fileName">依赖文件名或路径</param>
        public static void Insert(string key ,object value,string fileName)
        {
            HttpRuntime.Cache.Insert(key, value, new CacheDependency(fileName));
        }



        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        /// <param name="fileName">依赖文件名或路径</param>
        /// <param name="freeTime">滑动过期时间</param>
        /// <param name="IsAbsolute">true：绝对过期  false：滑动过期</param>
        public static void Insert(string key, object value, string fileName, int time, bool IsAbsolute)
        {
            if (IsAbsolute)
                HttpRuntime.Cache.Insert(key, value, new CacheDependency(fileName), DateTime.Now.AddSeconds(time), System.Web.Caching.Cache.NoSlidingExpiration);
            else
                HttpRuntime.Cache.Insert(key, value, new CacheDependency(fileName), System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(time));
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        /// <param name="cmd">数据库操作对象</param>
        public static void Insert(string key, object value, SqlCommand cmd)
        {
            HttpRuntime.Cache.Insert(key, value, new SqlCacheDependency(cmd));
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">缓存对象</param>
        /// <param name="cmd">数据库操作对象</param>
        /// <param name="time">过期时间</param>
        /// <param name="IsAbsolute">true：绝对过期  false：滑动过期</param>
        public static void Insert(string key, object value, SqlCommand cmd, int time, bool IsAbsolute)
        {
            if (IsAbsolute)
                HttpRuntime.Cache.Insert(key, value, new SqlCacheDependency(cmd), DateTime.Now.AddSeconds(time), System.Web.Caching.Cache.NoSlidingExpiration);
            else
                HttpRuntime.Cache.Insert(key, value, new SqlCacheDependency(cmd), System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(time));
        }


        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key)
        {
            return (T)HttpRuntime.Cache.Get(key);
        }


        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(string key,Func<T> func)
        {
            T result = (T)HttpRuntime.Cache.Get(key);
            if (result != null)
            {
                return result;
            }
                
            else
            {
                result = func();
                return result;
            }

        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key">关键字</param>
        public static void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }
    }
}
