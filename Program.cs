using System;

namespace abstract_factory
{
  internal class Program
  {
    static void Main(string[] args)
    {
      IGUIFactory easternFactory = new EasternGUIFactory();
      Client client1 = new Client(easternFactory);
      client1.CreateUI();

      IGUIFactory westernFactory = new WesternGUIFactory();
      Client client2 = new Client(westernFactory);
      client2.CreateUI();
    }
  }

  public interface IGUIFactory
  {
    IButton CreateButton();
    ICheckbox CreateCheckbox();
  }

  public interface IButton
  {
    void Paint();
  }

  public interface ICheckbox
  {
    void Paint();
  }

  public class EasternGUIFactory : IGUIFactory
  {
    public IButton CreateButton()
    {
      return new EasternButton();
    }

    public ICheckbox CreateCheckbox()
    {
      return new EasternCheckbox();
    }
  }

  public class WesternGUIFactory : IGUIFactory
  {
    public IButton CreateButton()
    {
      return new WesternButton();
    }

    public ICheckbox CreateCheckbox()
    {
      return new WesternCheckbox();
    }
  }

  public class EasternButton : IButton
  {
    public void Paint()
    {
      Console.WriteLine("Рисуем кнопку в восточном стиле");
    }
  }

  public class WesternButton : IButton
  {
    public void Paint()
    {
      Console.WriteLine("Рисуем кнопку в западном стиле");
    }
  }

  // Конкретный чекбокс "Восточный стиль"
  public class EasternCheckbox : ICheckbox
  {
    public void Paint()
    {
      Console.WriteLine("Рисуем чекбокс в восточном стиле");
    }
  }

  public class WesternCheckbox : ICheckbox
  {
    public void Paint()
    {
      Console.WriteLine("Рисуем чекбокс в западном стиле");
    }
  }

  public class Client
  {
    private IButton button;
    private ICheckbox checkbox;

    public Client(IGUIFactory factory)
    {
      button = factory.CreateButton();
      checkbox = factory.CreateCheckbox();
    }

    public void CreateUI()
    {
      button.Paint();
      checkbox.Paint();
    }
  }
}
