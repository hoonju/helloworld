// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


void Test() => Console.WriteLine("\nTest is being called...");


var handler = InputHandler.One;
handler.callbacks += Test;

while (handler.IsRunnable)
{
     handler.Run();
}



class InputHandler
{
    private static InputHandler? __handler;
    public static InputHandler One
    {
        get => __handler ?? (__handler = new InputHandler());
    }
    public delegate void __TypeDelegateHandler();
    public event __TypeDelegateHandler? callbacks;
     public void Run()
     {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Escape)
            {
                callbacks = null;
            }
            else
            {
                callbacks!();
            }
        }
    }

    public bool IsRunnable
    {
        get => callbacks != null;
    }
}






        