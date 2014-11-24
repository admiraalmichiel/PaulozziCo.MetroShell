using System;
using System.IO.IsolatedStorage;

namespace PaulozziCo.MetroShell.Utilities
{
    public static class IsolatedStorageHelper<T>
    {
        /// <summary>
        /// Get the isolated storage settings intance
        /// </summary>
        private static IsolatedStorageSettings _isolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings;

        public static void RegisterInstence(IsolatedStorageSettings isolatedStorageSettings)
        {
            _isolatedStorageSettings = isolatedStorageSettings;
        }

        /// <summary>
        /// Removes the data in isolated storage by specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public static void Remove(string key)
        {
            try
            {
                if (_isolatedStorageSettings != null)
                {
                    _isolatedStorageSettings.Contains(key);
                    {
                        _isolatedStorageSettings.Remove(key);

                        _isolatedStorageSettings.Save();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tries store the data in isolated storage.
        /// </summary>
        /// <param name="Obj">The obj.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static bool TryStore(T Obj, string key)
        {
            try
            {
                if (Obj != null || _isolatedStorageSettings != null)
                {
                    _isolatedStorageSettings.Contains(key);
                    {
                        _isolatedStorageSettings.Remove(key);
                    }

                    _isolatedStorageSettings.Add(key, Obj);

                    _isolatedStorageSettings.Save();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tries store the data in isolated storage.
        /// </summary>
        /// <param name="Obj">The obj.</param>
        /// <param name="key">The key.</param>
        /// <param name="callback">The callback.</param>
        public static void TryStore(T Obj, string key, Action<T> callback)
        {
            try
            {
                if (Obj != null || _isolatedStorageSettings != null)
                {
                    _isolatedStorageSettings.Contains(key);
                    {
                        _isolatedStorageSettings.Remove(key);
                    }

                    _isolatedStorageSettings.Add(key, Obj);

                    _isolatedStorageSettings.Save();

                    callback(Obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tries store data in isolated storage by object type name.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        public static bool TryStoreByTypeName(T obj, int? version = null)
        {
            try
            {
                string key = typeof(T).Name;

                if (String.IsNullOrEmpty(key)) return false;

                if (obj != null || _isolatedStorageSettings != null)
                {
                    if (version.HasValue)
                        key += "_" + version.ToString();

                    _isolatedStorageSettings.Contains(key);
                    {
                        _isolatedStorageSettings.Remove(key);
                    }

                    _isolatedStorageSettings.Add(key, obj);

                    _isolatedStorageSettings.Save();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return false;
        }

        /// <summary>
        /// Tries get data in isolated storage by object type name.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        public static T TryGetByTypeName(int? version = null)
        {
            string key = typeof(T).Name;

            if (!String.IsNullOrEmpty(key))
            {
                if (version.HasValue)
                    key += "_" + version.ToString();

                return TryGet(key);
            }

            return default(T);
        }

        /// <summary>
        /// Tries get data in isolated storage by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static T TryGet(string key)
        {
            try
            {
                T result;
                if (_isolatedStorageSettings.TryGetValue(key, out result))
                {
                    if (result is T)
                    {
                        return (T)result;
                    }
                }
            }
            catch (Exception)
            {
                return default(T);
            }

            return default(T);
        }

        public static bool TryGet<T>(string key, out T value)
        {
            return _isolatedStorageSettings.TryGetValue(key, out value);
        }

        /// <summary>
        /// Tries get data in isolated storage by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="callback">The callback.</param>
        public static void TryGet(string key, Action<T> callback)
        {
            try
            {
                T result;
                if (_isolatedStorageSettings.TryGetValue(key, out result))
                {
                    if (result is T)
                    {
                        callback((T)result);
                    }
                }
            }
            catch (Exception)
            {
                callback(default(T));
            }
        }
    }
}
