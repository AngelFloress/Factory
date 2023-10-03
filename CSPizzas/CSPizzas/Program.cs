using System;
using System.Collections.Generic;

namespace Patron_Factory_Method
{
    // Flores Gomez Jose Angel 19210933
    class Program
    {
        // MENU PARA ELEGIR EL ESTILO DE PIZZAS
       
        static void Main(string[] args)
        {
            Console.WriteLine("Flores Gomez Jose Angel 19210933");
            PizzaStore NYP = new NYPizzaStore();
            PizzaStore CP = new ChicagoPizzaStore();
            int y, x = 0;
            while (x == 0)
            {
                try
                {
                    Console.WriteLine("----------PIZZAS----------");
                    Console.WriteLine("1.- Pizza Estilo New York");
                    Console.WriteLine("2.- Pizza Estilo Chicago");
                    Console.WriteLine("3.- Salir del Programa");
                    Console.Write("Ingresa una opcion: ");
                    y = int.Parse(Console.ReadLine());
                    switch (y)
                    {
                        
                        case 1:
                            Console.Clear();
                            Orden(NYP);
                            break;
                        case 2:
                            Console.Clear();
                            Orden(CP);
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Presiona Enter para salir del Programa");
                            x = 1;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.Clear();
                }
            }
            Console.ReadKey();
        }


        // Flores Gomez Jose Angel 19210933
        //MENU PARA ELEGIR EL TIPO DE PIZZAS QUE QUIERES
        static void Orden(PizzaStore PS)
        {
            int opcion, x = 0;
            while (x == 0)
            {
                try
                {
                    Console.WriteLine("Pizzas Disponibles: ");
                    Console.WriteLine("1.- Queso");
                    Console.WriteLine("2.- Vegetariana");
                    Console.WriteLine("3.- Almeja");
                    Console.WriteLine("4.- Pepperoni");
                    Console.WriteLine("5.- Volver");
                    Console.Write("Ingresa una opcion: ");
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Pedido(PS, "Chesse");
                            x = 1;
                            break;
                        case 2:
                            Console.Clear();
                            Pedido(PS, "Veggie");
                            x = 1;
                            break;
                        case 3:
                            Console.Clear();
                            Pedido(PS, "Clam");
                            x = 1;
                            break;
                        case 4:
                            Console.Clear();
                            Pedido(PS, "Pepperoni");
                            x = 1;
                            break;
                        case 5:
                            Console.WriteLine("Presiona Enter para volver");
                            Console.ReadKey();
                            Console.Clear();
                            x = 1;
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                //Errores
                catch (FormatException e)
                {
                    Console.Clear();
                }
            }

        }

        static void Pedido(PizzaStore PS, string name)
        {
            Pizza pizza;
            pizza = PS.orderPizza(name);
            Console.WriteLine(pizza.getName() + "\n");
            Console.WriteLine("========[Presiona Enter para volver]");
            Console.ReadKey();
            Console.Clear();
        }
    }



    // Flores Gomez Jose Angel 19210933
    //CLASE PARA LA PREPARACION DE PIZZAS
    public abstract class PizzaStore
    {
        internal abstract Pizza createPizza(string item);
        public virtual Pizza orderPizza(string type)
        {
            Pizza pizza = createPizza(type);
            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();
            return pizza;
        }
    }

    // Flores Gomez Jose Angel 19210933
    // CLASE PARA MOSTRAR LA PREPARACION DE LAS PIZZAS
    public abstract class Pizza
    {
        internal string name;
        internal string dough;
        internal string sauces;
        internal List<string> toppings = new List<string>();

        public virtual void prepare()
        {
            Console.WriteLine("Preparando: " + name);
            foreach (string topping in toppings)
            {
                Console.WriteLine("" + topping);
            }
        }

        public virtual void bake()
        {
            Console.WriteLine("Hornea la pizza");
        }

        public virtual void cut()
        {
            Console.WriteLine("Corta la Pizza");
        }

        public virtual void box()
        {
            Console.WriteLine("Empaca la pizza");
        }

        public virtual string getName()
        {
            return name;
        }
    }

    // Flores Gomez Jose Angel 19210933
    // CLASE PARA LA SELECCION DE TIPO DE PIZZA EN NYC
    public class NYPizzaStore : PizzaStore
    {
        internal override Pizza createPizza(string name)
        {
            if (name == "Chesse")
            {
                return new NYStyleChessePizza();
            }
            else if (name == "Veggie")
            {
                return new NYStyleVeggiePizza();
            }
            else if (name == "Clam")
            {
                return new NYStyleClamPizza();
            }
            else if (name == "Pepperoni")
            {
                return new NYStylePepperoniPizza();
            }
            else
            {
                return null;
            }
        }
    }

    // Flores Gomez Jose Angel 19210933
    // CLASE PARA LA SELECCION DE TIPO DE PIZZA EN CHICAGO
    public class ChicagoPizzaStore : PizzaStore
    {
        internal override Pizza createPizza(string name)
        {
            if (name == "Chesse")
            {
                return new ChicagoStyleChessePizza();
            }
            else if (name == "Veggie")
            {
                return new ChicagoStyleVeggiePizza();
            }
            else if (name == "Clam")
            {
                return new ChicagoStyleClamPizza();
            }
            else if (name == "Pepperoni")
            {
                return new ChicagoStylePepperoniPizza();
            }
            else
            {
                return null;
            }
        }
    }


    // Flores Gomez Jose Angel 19210933
    // PREPARACION PARA LA PIZZA DE QUESO ESTILO NYC
    public class NYStyleChessePizza : Pizza
    {
        public NYStyleChessePizza()
        {
            name = "Pizza de Queso Estilo NY";
            dough = "Masa stilo NY";
            sauces = "Salsa de tomate estilo NY";
            toppings.Add("Queso Rallado Reggiano");
        }
    }
    // PREPARACION PARA LA PIZZA DE VEGETALES ESTILO NYC
    public class NYStyleVeggiePizza : Pizza
    {
        public NYStyleVeggiePizza()
        {
            name = "Pizza Vegetariana Estilo NY";
            dough = "Masa stilo NY";
            sauces = "Salsa de tomate estilo NY";
            toppings.Add("Queso Rallado Reggiano");
            toppings.Add("Hongos");
            toppings.Add("Ajo");
            toppings.Add("Chiles");
            toppings.Add("Cebolla");
        }
    }
    // PREPARACION PARA LA PIZZA DE ALMEJA ESTILO NYC
    public class NYStyleClamPizza : Pizza
    {
        public NYStyleClamPizza()
        {
            name = "Pizza de Almeja Estilo NY";
            dough = "Masa stilo NY";
            sauces = "Salsa de tomate estilo NY";
            toppings.Add("Queso Rallado Reggiano");
            toppings.Add("Alemejas Frescas");
        }
    }
    // PREPARACION PARA LA PIZZA DE PEPERONI ESTILO NYC
    public class NYStylePepperoniPizza : Pizza
    {
        public NYStylePepperoniPizza()
        {
            name = "Pizza de Peperoni Estilo NY";
            dough = "Masa stilo NY";
            sauces = "Salsa de tomate estilo NY";
            toppings.Add("Queso Rallado Reggiano");
            toppings.Add("Pepperoni");
        }
    }

    // Flores Gomez Jose Angel 19210933
    // PREPARACION PARA LA PIZZA DE QUESO ESTILO CHICAGO
    public class ChicagoStyleChessePizza : Pizza
    {
        public ChicagoStyleChessePizza()
        {
            name = "Pizza de Queso Estilo Chicago";
            dough = "Masa stilo Chicago";
            sauces = "Salsa de tomate estilo Chicago";
            toppings.Add("Queso Rallado Chicago");
        }
    }
    // PREPARACION PARA LA PIZZA DE VEGETALES ESTILO CHICAGO
    public class ChicagoStyleVeggiePizza : Pizza
    {
        public ChicagoStyleVeggiePizza()
        {
            name = "Pizza Vegetariana Estilo Chicago";
            dough = "Masa stilo Chicago";
            sauces = "Salsa de tomate estilo Chicago";
            toppings.Add("Queso Rallado Chicago");
            toppings.Add("Hongos");
            toppings.Add("Ajo");
            toppings.Add("Chiles");
            toppings.Add("Cebolla");
        }
    }
    // PREPARACION PARA LA PIZZA DE ALMEJA ESTILO CHICAGO
    public class ChicagoStyleClamPizza : Pizza
    {
        public ChicagoStyleClamPizza()
        {
            name = "Pizza de Almeja Estilo Chicago";
            dough = "Masa stilo Chicago";
            sauces = "Salsa de tomate estilo Chicago";
            toppings.Add("Queso Rallado Chicago");
            toppings.Add("Alemejas Cocidas");
        }
    }
    // PREPARACION PARA LA PIZZA DE PEPERONI ESTILO CHICAGO
    public class ChicagoStylePepperoniPizza : Pizza
    {
        public ChicagoStylePepperoniPizza()
        {
            name = "Pizza de Peperoni Estilo Chicago";
            dough = "Masa stilo NY";
            sauces = "Salsa de tomate estilo Chicago";
            toppings.Add("Queso Rallado Chicago");
            toppings.Add("Pepperoni");
        }
    }
    
}

