using System;

namespace Electrodomesticos
{
    public abstract class Electrodomesticoss{
        protected double precio, peso;
        protected string color;
        protected char consumo_energetico;
        /*  color blanco
            color negro
            color rojo
            color azul
            color gris   */

    public Electrodomesticoss(){
        precio = 100;
        peso = 5;
        color = "blanco";
        consumo_energetico = 'F';
    }

    public Electrodomesticoss(double precio, double peso){
        this.precio = precio;
        this.peso = peso;
        this.color = "blanco";
        this.consumo_energetico = 'F';
    }
    public Electrodomesticoss(double precio, double peso, string color, char consumo_energetico){
        this.precio = precio;
        this.peso = peso;
        this.color = color;
        this.consumo_energetico = consumo_energetico;
    }
    public virtual double Get_precio(){
        return precio;
    }
    public virtual double Get_peso(){
        return peso;
    }
    public  virtual string Get_color(){
        return color;
    }
    public virtual char Get_consumo_energetico(){
        return consumo_energetico;
    }
    public virtual void comprobar_Consumo_Energetico(char letra){
        string valores = "ABCDEF";
        if(valores.IndexOf(Char.ToUpper(letra)) > 0){
            this.consumo_energetico = char.ToUpper(letra);
        }
        else{
             this.consumo_energetico = 'F';
        }
    }
    public virtual void comprobar_Color(string color){
        string[] colores = new string[6];
        colores[0] = "blanco";
        colores[1] = "negro";
        colores[2] = "rojo";
        colores[3] = "azul";
        colores[4] = "gris";
        
        foreach(string cl in colores){
            color = color.ToLower();
            if(color != cl){
                this.color = "blanco";
            }
            else{
                this.color = color;
            }
        }
    }

    public virtual double precio_final(){
        double precio_fin = this.precio;
        //Precio final del consumo energetico
        switch(consumo_energetico){
            case 'A':
            precio_fin += 100;
            break;
            
            case 'B':
            precio_fin += 80;
            break;
            
            case 'C':
            precio_fin += 60;
            break;
            
            case 'D':
            precio_fin += 50;
            break;

            case 'E':
            precio_fin += 30;
            break;

            case 'F':
            precio_fin += 10;
            break;

        }
        //precio final del peso
        if(peso >= 0 && peso < 20){
            precio_fin += 10;
        }
        else if(precio_fin >= 20 && precio_fin < 50){
            precio_fin += 50;
        }
        else if(precio_fin >= 50 && precio_fin < 80){
            precio_fin += 80;
        }
        else if(precio_fin >= 80){
            precio_fin += 100;
        }
        return precio + precio_fin;
    }
}
class Lavadora : Electrodomesticoss{
    double carga = 5;
    public Lavadora(double precio, double peso){
        this.precio = precio;
        this.peso = peso;
        this.color = "blanco";
        this.consumo_energetico = 'F';
        carga = 5;
    }
    public Lavadora(double precio, double peso, string color, char consumo_energetico, double carga){
        this.precio = precio;
        this.peso = peso;
        this.color = color;
        this.consumo_energetico = consumo_energetico;
        this.carga = carga;
    }
    public double Get_carga(){
        return carga;
    }
    public override double precio_final()
    {
        double precio_fin = precio_final();
        if(peso > 30){
            precio_fin += 50;
        }
        return precio_fin;
    }
}
class Television : Electrodomesticoss{
    double resolucion = 20;
    bool sintonizador_TDT = false;
    public Television(double peso, double precio){
        this.precio = precio;
        this.peso = peso;
        this.color = "blanco";
        this.consumo_energetico = 'F';
        this.resolucion = 20;
        this.sintonizador_TDT = false;
    }
    public Television(double precio, double peso, string color,char consumo_energetico,double resolucion, bool sintonizador_TDT){
        this.precio = precio;
        this.peso = peso;
        this.color = color;
        this.consumo_energetico = consumo_energetico;
        this.resolucion = resolucion;
        this.sintonizador_TDT = sintonizador_TDT;
    }
    public double Get_resolucion(){
        return resolucion;
    }
    public bool Get_sintonizador_TDT(){
        return sintonizador_TDT;
    }
        public override double precio_final()
        {
            double precio_fin = precio_final();
            if(resolucion > 40){
                precio = precio *(1.30);
            }
            if((resolucion > 40) && (sintonizador_TDT = true)){
                precio += 50;
            }
            return precio_fin;
        }
}
class Ejecutable{
    public void Mostar1(){
    Electrodomesticoss[] tienda = new Electrodomesticoss[10];
    tienda[0] = new Lavadora(200,60,"azul",'F',6);
    tienda[1] = new Lavadora(400,80,"verde",'A',8);
    tienda[2] = new Television(500,70,"gris",'B',20, true);
    tienda[3] = new Television(200,76,"GrIs",'D',40, true);
    tienda[4] = new Lavadora(200,46,"ROJO",'E',7);
    tienda[5] = new Lavadora(900,90,"amarillo",'E',10);
    tienda[6] = new Television(30,12,"naranja",'C',400, false);
    tienda[7] = new Television(60,34,"Magenta",'C',300, true);
    tienda[8] = new Lavadora(80,100,"negro",'A',2);
    tienda[9] = new Lavadora(45,45,"NeGRo",'F',1);

    double suma_lavadora = 0;
    double suma_television = 0;

    for(int i = 0; i < tienda.Length; i++){
        if(tienda[i] is Lavadora){
            suma_lavadora += tienda[i].precio_final();
        }
        if(tienda[i] is Television){
            suma_television += tienda[i].precio_final();
        }
    }

    Console.WriteLine("La suma total de las lavadoras es {0}", suma_lavadora);
    Console.WriteLine("La suma total de los televisores es de {0}", suma_television);
    }
}
    class Program
    {
        static void Main(string[] args)
        {
            Ejecutable eje = new Ejecutable();
            eje.Mostar1();
        }
    }
}
