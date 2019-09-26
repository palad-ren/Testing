using System.IO;
using System.Collections.Generic;

public class Util
{
    string path = @"C:\Users\renato.gomes\source\repos\Personal\Testing\Assets\SaveFiles\[Name]Info.txt";
    public void Write(object obj)
    {
        path = path.Replace("[Name]", obj.GetType().ToString());

        File.WriteAllText(path, "");
        using (StreamWriter sw = File.AppendText(path))
        {
            foreach (var item in obj.GetType().GetProperties())
            {
                sw.WriteLine("<" + item.Name + ">\"" + item.GetValue(obj, item.GetIndexParameters()) + "\"</" + item.Name + ">");
            }
        }
    }

    public Player Read(object obj)
    {
        path = path.Replace("[Name]", obj.GetType().ToString());

        var player = new Player();

        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                if (s.Contains("<Id>")) player.Id = int.Parse(s.Split('"')[1]);
                if (s.Contains("<Name>")) player.Name = s.Split('"')[1];
                if (s.Contains("<Speed>")) player.Speed = float.Parse(s.Split('"')[1]);
                if (s.Contains("<RotationSpeed>")) player.RotationSpeed = float.Parse(s.Split('"')[1]);
            }
        }

        return player;
    }

    public object Read2(object obj)
    {
        path = path.Replace("[Name]", obj.GetType().ToString());

        var listS = new List<string>();
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                listS.Add(s);
            }
        }
        foreach(var item in obj.GetType().GetProperties())
        {
            //item.SetValue = item.GetType().pa(listS.Find(x => x.Contains(item.Name)).Split('"')[1]);
        }

        return obj;
    }

    public void Clear(object obj)
    {
        path = path.Replace("[Name]", obj.GetType().ToString());

        File.WriteAllText(path, "");
    }

    /*
    public IList<T> MapeiaRetornoParaListaDeEntidades<T>(DataSet dataSet, bool ignorarColunasAusentes = false) where T : new()
        {
            var retorno = new List<T>();

            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                var entidade = new T();
                var row = dataSet.Tables[0].Rows[i];

                typeof(T).GetProperties().ToList().ForEach(propriedade =>
                {
                    object saida = null;
                    string dado = "";
                    var ignorarColuna = !row.Table.Columns.Contains(propriedade.Name) && ignorarColunasAusentes;

                    if (!ignorarColuna)
                    {
                        try { dado = row[propriedade.Name]?.ToString(); }
                        catch { throw new Exception("Valor não encontrado para a variavel " + propriedade.Name); }

                        Type tipo = propriedade.PropertyType.GetTypeInfo();
                        MapeiaTipoParaGet(dado, tipo, out saida);
                        propriedade.SetValue(entidade, saida);
                    }
                });

                retorno.Add(entidade);
            }

            return retorno;
        }

        public T MapeiaRetornoParaEntidade<T>(DataSet dataSet) where T : new()
        {

            if (dataSet.Tables[0]?.Rows.Count == 0)
                return default(T);

            var entidade = new T();
            var row = dataSet.Tables[0].Rows[0];

            typeof(T).GetProperties().ToList().ForEach(propriedade =>
            {
                object saida = null;
                string dado = "";
                try { dado = row[propriedade.Name]?.ToString(); }
                catch { }

                Type tipo = propriedade.PropertyType.GetTypeInfo();
                MapeiaTipoParaGet(dado, tipo, out saida);
                propriedade.SetValue(entidade, saida);
            });

            return entidade;
        }

        public void MapeiaTipoParaGet(string valor, Type tipo, out object saida)
        {
            if (tipo == typeof(string))
            {
                if (valor == "")
                {
                    saida = null;
                    return;
                }

                saida = valor;
                return;
            }

            if (string.IsNullOrEmpty(valor))
            {
                saida = null;
                return;
            }

            if (valor == "")
            {
                saida = null;
                return;
            }

            if (tipo == typeof(long) || tipo == typeof(long?))
            {
                saida = Convert.ToInt64(valor);
                return;
            }

            if (tipo == typeof(int) || tipo == typeof(int?))
            {
                saida = valor.ToInt();
                return;
            }

            if (tipo == typeof(DateTime) || tipo == typeof(DateTime?))
            {
                saida = Convert.ToDateTime(valor);
                return;
            }
            if (tipo == typeof(decimal) || tipo == typeof(decimal?))
            {
                saida = Convert.ToDecimal(valor);
                return;
            }
            if (tipo == typeof(char) || tipo == typeof(char?))
            {
                saida = valor.ToCharArray()[0];
                return;
            }
            if (tipo == typeof(bool))
            {
                saida = Convert.ToBoolean(valor);
                return;
            }
            if (tipo == typeof(double) || tipo == typeof(double?))
            {
                saida = Convert.ToDouble(valor);
                return;
            }

            saida = valor;
        }

        public string MapeiaPropriedadesParaSQL<T>(string sql, T objetoParaMapear)
        {
            sql = sql + " "; //adicionado para se encaixar nos replaces abaixo;
            foreach (var VARIABLE in objetoParaMapear.GetType().GetProperties().ToList())
            {
                object variavel = VARIABLE.GetValue(objetoParaMapear);
                var valorFormatado = variavel != null ? ObterValorFormatado(variavel) : "null";
                sql = ReplaceVariavel(sql, VARIABLE.Name, valorFormatado);
            }

            return sql;
        }

        public string ReplaceVariavel(string sql, string nomeVariavel, string valor)
        {
            sql = sql.Replace($":{nomeVariavel} ", $"{valor} ");
            sql = sql.Replace($":{nomeVariavel};", $"{valor};");
            sql = sql.Replace($":{nomeVariavel},", $"{valor},");
            sql = sql.Replace($":{nomeVariavel})", $"{valor})");
            sql = sql.Replace($":{nomeVariavel}\n", $"{valor}\n");
            sql = sql.Replace($":{nomeVariavel}\r\n", $"{valor}\r\n");

            return sql;
        }
    */

}
