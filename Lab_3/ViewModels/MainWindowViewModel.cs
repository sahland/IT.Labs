using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Avalonia.Input;

namespace Lab_3.ViewModels;

public class MainWindowViewModel
{
    
    private object? _classFromLab2;
    
    private String _route = "";
    public List<string> NameClass { get; set; }

    public ObservableCollection<string> MethodsClass { get; }
    
    public ObservableCollection<string> FieldsClass { get; }

    private HashSet<object> _points;
    
    private double _radiusA;
    private double _radiusB;


    public String Route
    {
        get => _route;
        set
        {
            _route = value;
            GetListClass();
        }
    }
    public double RadiusA
    {
        get => _radiusA;
        set => _radiusA = value;
    }
    
    public double RadiusB
    {
        get => _radiusB;
        set => _radiusB = value;
    }
    
    public MainWindowViewModel()
    {
        NameClass = new List<string>();
        MethodsClass = new ObservableCollection<string>();     
        FieldsClass = new ObservableCollection<string>();
        _points = new HashSet<object>();
    }
    
    public string PointerMsg (PointerPoint point)
    {
        var x = point.Position.X;
        var y = point.Position.Y;
        
        Type? pointType = Assembly.LoadFrom(_route).GetType("Lab_2.Models.Point");
        
        switch (Type)
        { 
            case "Lab_2.Models.Point" or "Lab_2.Models.Ellipse":
                _points.Clear();
                _points.Add(Activator.CreateInstance(pointType, args: [x, y]));
                break;
            case "Lab_2.Models.Line":
                if (_points.Count == 2) _points.Clear();
                _points.Add(Activator.CreateInstance(pointType, args: [x, y]));
                break;
            case "Lab_2.Models.Polygon": 
                _points.Add(Activator.CreateInstance(pointType, args: [x, y]));
                break; 
            case "":
                return "Выберите фигуру!";
        }
        
        string result = "Точки: \n[\n";
        foreach (var p in _points)
        {
            result += p + ";\n";
        }
        result += "]\n";
                
        return result;
    }

    public string Type { get; set; } = "";

    public void ClearPoints()
    {
        _points.Clear();
    }

    public string Characteristics()
    {
        if (_points.Count == 0) return "Недостаточное кол-во точек.";
        string result = "";

        switch (Type)
        {
            case "Lab_2.Models.Point":
                _classFromLab2 = _points.First();
                result = (string) MethodFromClass("BaseInformation");
                break;
            case "Lab_2.Models.Line":
                CreateClass(Type, [_points.First(), _points.Last()]);
                result = (string) MethodFromClass("BaseInformation");
                break;
            case "Lab_2.Models.Polygon":
                CreateClass(Type, [_points.ToList()]);
                result = (string) MethodFromClass("BaseInformation");
                break;
            case "Lab_2.Models.Ellipse":
                CreateClass(Type, [_points.First(), RadiusA, RadiusB]);
                result = (string) MethodFromClass("BaseInformation");
                break;
        }
        return result;
    }
    
    public void GetListClass() 
    {
        NameClass = new List<string>();

        string assemblyPath = _route;

        Assembly assembly = Assembly.LoadFrom(assemblyPath);

        Type[] types = assembly.GetTypes();

        var modelsTypes = types.Where(t => t.Namespace == "Lab_2.Models");

        foreach (Type type in modelsTypes)
        {
            NameClass.Add(type.FullName);
        }
    }
    
    public ObservableCollection<string> GetListMethods(string nameClass)
    {
        MethodsClass.Clear();

        Assembly assembly = Assembly.LoadFrom(_route);
            
        Type classType = assembly.GetType(nameClass);                        

        MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        foreach (MethodInfo method in methods)
        {                
            MethodsClass.Add(method.Name);
        }

        return MethodsClass;
    }
    
    public ObservableCollection<string> GetListFields(string nameClass)
    {
        FieldsClass.Clear();
        
        Assembly assembly = Assembly.LoadFrom(_route);
            
        Type classType = assembly.GetType(nameClass);                        

        FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (FieldInfo method in fields)
        {                
            FieldsClass.Add(method.Name);
        }

        return FieldsClass;
    }
    public void CreateClass(String className, object[] parameters)
    {
        Assembly assembly = Assembly.LoadFrom(_route);

        Type? classType = assembly.GetType(className);
        
        var listType = typeof(List<>);
        Type[] typeArgs = { _points.First().GetType() };
        var genericListType = listType.MakeGenericType(typeArgs);
        var typedList = (IList)Activator.CreateInstance(genericListType);
        
        foreach (var item in _points)
        {
            typedList.Add(item);
        }
        
        
        if (classType != null)
        {
            
            switch (classType.FullName)
            {
                case "Lab_2.Models.Ellipse":
                    _classFromLab2 = Activator.CreateInstance(type: classType, args: parameters);
                    break;
                case "Lab_2.Models.Point":
                    _classFromLab2 = Activator.CreateInstance(type: classType, args: parameters);
                    break;
                case "Lab_2.Models.Polygon":
                        //Console.WriteLine(temp.GetType());
                        _classFromLab2 = Activator.CreateInstance(type: classType, args: typedList);
                    break;
                case "Lab_2.Models.Line":
                    _classFromLab2 = Activator.CreateInstance(type: classType, args: parameters);
                    break;
            }
        }
        else
        {
            Console.WriteLine("Класс не найден");                
        }

    }
    public object MethodFromClass(string nameMethod, string? parameter = null)
        {
            try
            {
                if (_classFromLab2 == null)
                {
                    throw new InvalidOperationException("Класс не был выбран.");
                }

                MethodInfo method = _classFromLab2.GetType().GetMethod(nameMethod);

                if (method == null)
                {
                    throw new MissingMethodException("Метод не найден.");
                }
                else
                {
                    ParameterInfo[] methodParameters = method.GetParameters();

                    if (methodParameters.Length == 0)
                    {
                        ;
                        object returnValue = method.Invoke(_classFromLab2, null);

                        if (method.ReturnType != typeof(void))
                        {
                           Console.WriteLine($"Результат выполнения метода: {method} - {returnValue}");
                        }

                        return returnValue;
                    }
                    else
                    {
                        double parsedValue;
                        if (double.TryParse(parameter, out parsedValue))
                        {
                            object[] parameters = { parsedValue };
                            object returnValue = method.Invoke(_classFromLab2, parameters);

                            if (method.ReturnType != typeof(void))
                            {
                                Console.WriteLine($"Результат выполнения метода: {method} - {returnValue}");
                            }

                            return returnValue;
                        }
                        else
                        {
                            Console.WriteLine("Вы не передали значение в поле для ввода или оно строка");
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения метода: {ex.Message}");
                return null;
            }
        }
    
}