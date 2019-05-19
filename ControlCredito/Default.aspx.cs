using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlCredito
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            user_monto_list.Items.Add(new ListItem("Selecciona un valor", 0.ToString()));
            for (int i = 1; i <= 30; i++)
            {
                user_monto_list.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        protected void Enviar_Click(object sender, EventArgs e)
        {
            String strUser_name = user_name.Text;
            String strUser_monto = user_monto.Text;
            String strList = user_monto_list.Text;
            double intUser_monto = 0;
            int user_year = 0;
            double uf = 27284.16;
            double montoFinal =0;
            bool verificadoN = false;
            bool verificadoM = false;
            bool verificadoL = false;
            bool verificadoC1 = false;
            bool verificadoC2 = false;

            bool isNumeric = double.TryParse(strUser_monto, out intUser_monto);
            
            //Validacion de user_name
            {
                //No debe tener numeros en ningunos de sus digitos
                if(strUser_name=="")
                {
                    error_name.Text = "Este campo no puede estar vacio";
                    verificadoN = false;
                }
                else
                {
                    if (Regex.IsMatch(strUser_name, @"^[a-zA-Z]+$"))
                    {
                        error_name.Text = "";
                        verificadoN = true;
                    }
                    else
                    {
                        error_name.Text = "El nombre solo debe contener letras";
                        verificadoN = false;
                    }
                }
            }

            //Validacion de user_monto
            {
                if (strUser_monto == null || strUser_monto == "")
                {
                    error_monto.Text = "Este campo no puede estar vacio";
                    verificadoM = false;
                }
                else
                {
                    if (!isNumeric)
                    {
                        error_monto.Text = "Solo numeros";
                        verificadoM = false;
                    }
                    else
                    {
                        intUser_monto = Convert.ToInt32(strUser_monto);
                        if (intUser_monto < 0)
                        {
                            error_monto.Text = "El numero debe ser mayor a 0";
                            verificadoM = false;
                        }
                        else
                        {
                            error_monto.Text = "";
                            montoFinal = intUser_monto * uf;
                            verificadoM = true;
                        }
                    }
                }
            }

            //Validacion de list
            {
                if (strList == "0")
                {
                    error_list.Text = "Debe seleccionar un valor";
                    verificadoL = false;
                }
                else
                {
                    verificadoL = true;
                    error_list.Text = "";
                    user_year = Convert.ToInt32(strList);
                    if(user_year < 11)
                    {
                        montoFinal = montoFinal + (montoFinal * 0.3);
                    }else if(user_year < 21)
                    {
                        montoFinal = montoFinal + (montoFinal * 0.35);
                    }else if(user_year > 21)
                    {
                        montoFinal = montoFinal + (montoFinal * 0.4);
                    }
                }
            }

            //Validacion de checkBox's
            {
                //Desagravemen
                if (!(desTrue.Checked) && !(desFalse.Checked))
                {
                    error_des.Text = "Debes Seleccionar una opcion";
                    verificadoC1 = false;
                }
                else
                {
                    if (desTrue.Checked)
                    {
                        montoFinal = montoFinal + (montoFinal * 0.1);
                    }
                    error_des.Text = "";
                    verificadoC1 = true;
                }

                //Incendio
                if (!(burnTrue.Checked) && !(burnFalse.Checked))
                {
                    error_burn.Text = "Debes Seleccionar una opcion";
                    verificadoC2 = false;
                }
                else
                {
                    error_burn.Text = "";
                    if (burnTrue.Checked)
                    {
                        montoFinal = montoFinal + (montoFinal * 0.05);
                    }
                    verificadoC2 = true;
                }
            }

            if (verificadoN == true && verificadoM == true && verificadoL == true &&
                verificadoC1 == true && verificadoC2 == true)
            {
                valorFinal.Text ="El detalle es de $"+ montoFinal.ToString("0.###") + " pesos";
            }

        }
    }
}