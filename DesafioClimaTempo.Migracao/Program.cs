using DesafioClimaTempo.Domain.Context;
using DesafioClimaTempo.Domain.Enum;
using DesafioClimaTempo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioClimaTempo.Migracao
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var context = new EFContext())
            {

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();


                // Adicionar Estados
                #region Estados

                context.Estados.AddRange(

                new Domain.Model.Estado()
                {
                    Nome = "Acre",
                    Uf = "AC"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Alagoas",
                    Uf = "AL"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Amapá",
                    Uf = "AP"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Amazonas",
                    Uf = "AM"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Bahia",
                    Uf = "BA"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Ceará",
                    Uf = "CE"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Distrito Federal",
                    Uf = "DF"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Espírito Santo",
                    Uf = "ES"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Goiás",
                    Uf = "GO"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Maranhão",
                    Uf = "MA"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Mato Grosso",
                    Uf = "MT"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Mato Grosso do Sul",
                    Uf = "MS"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Minas Gerais",
                    Uf = "MG"
                }
                ,
                new Domain.Model.Estado()
                {
                    Nome = "Pará",
                    Uf = "PA"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Paraíba",
                    Uf = "PB"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Paraná",
                    Uf = "PR"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Pernambuco",
                    Uf = "PE"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Piauí",
                    Uf = "PI"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Rio de Janeiro",
                    Uf = "RJ"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Rio Grande do Norte",
                    Uf = "RN"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Rio Grande do Sul",
                    Uf = "RS"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Rondônia",
                    Uf = "RO"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Roraima",
                    Uf = "RR"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Santa Catarina",
                    Uf = "SC"
                },
                new Domain.Model.Estado()
                {
                    Nome = "São Paulo",
                    Uf = "SP"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Sergipe",
                    Uf = "SE"
                },
                new Domain.Model.Estado()
                {
                    Nome = "Tocantins",
                    Uf = "TO"
                });
                context.SaveChanges();

                #endregion

                // Adicionar Cidades
                #region Cidades

                List<Cidade> cidade = new List<Cidade>() {
                    new Cidade()
                    {
                        Nome = "Campo Grande",
                        EstadoId = 12
                    },
                    new Domain.Model.Cidade()
                    {
                        Nome = "Dourados",
                        EstadoId = 12
                    },
                    new Domain.Model.Cidade()
                    {
                        Nome = "São Paulo",
                        EstadoId = 25
                    },
                    new Domain.Model.Cidade()
                    {
                        Nome = "Bauru",
                        EstadoId = 25
                    },
                    new Domain.Model.Cidade()
                    {
                        Nome = "Camapuã",
                        EstadoId = 12
                    },
                    new Domain.Model.Cidade()
                    {
                        Nome = "Iguatemi",
                        EstadoId = 12
                    },
                    new Domain.Model.Cidade()
                    {
                        Nome = "Coxim",
                        EstadoId = 12
                    }};

                context.Cidades.AddRange(cidade);
                context.SaveChanges();

                #endregion

                // Adicionar Previsao Clima
                #region PrevisaoClima

                #region temperaturaAleatoria
                double[] temperaturaAleatoria = new double[]
                {
                            5.25,
                            8.33,
                            9.70,
                            10.99,
                            11.19,
                            12.29,
                            15.39,
                            16.29,
                            13.19,
                            7.09,
                            14.39,
                            19.29,
                            6.19,
                            20.3,
                            21.22,
                            22.5,
                            23.77,
                            24.55,
                            25.88,
                            26.97
                };
                #endregion

                List<PrevisaoClima> previsaoClimas = new List<PrevisaoClima>();

                Random numeroRandomico = new Random();

                for (int i = 1; i <= cidade.Count(); i++)
                {
                    var date = DateTime.Now.Date;
                    int seq = 0;

                    for (int c = 0; c <= 10; c++)
                    {

                        int ranNum = numeroRandomico.Next(0, temperaturaAleatoria.Count() - 1);

                        decimal temperatura = decimal.Parse(temperaturaAleatoria[ranNum].ToString());
                        decimal minimo = temperatura;
                        seq = seq < 6 ? seq + 1 : 0;

                        for (int b = 0; b <= 22; b++)
                        {

                            decimal maximo = minimo + 10;

                            date = date.AddMinutes(60);
                            previsaoClimas.Add(new Domain.Model.PrevisaoClima()
                            {
                                CidadeId = i,
                                DataPrevisao = date,
                                Clima = (ClimaEnum)seq,
                                TemperaturaMaxima = maximo,
                                TemperaturaMinima = minimo
                            });

                            minimo = minimo + 1;


                        }

                        date = date.AddDays(1).Date;
                    }
                }

                context.PrevisaoClima.AddRange(previsaoClimas);


                context.SaveChanges();
                #endregion
            }
        }
    }
}