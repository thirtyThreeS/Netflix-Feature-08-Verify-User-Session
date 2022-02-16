
static bool VerifySession(int[] pushOp, int[] popOp)
{
    int M = pushOp.Length;
    int N = popOp.Length;
    if (M != N) return false;

    Stack<int> stack = new();

    int i = 0;
    foreach (int pid in pushOp)
    {
        stack.Push(pid);
        while (stack.Count != 0 && stack.Peek() == popOp[i])
        {
            stack.Pop();
            i++;
        }
    }

    if (stack.Count == 0) return true;
    return false;
}


// Positive Case
int[] pushOp = { 1, 2, 3, 4, 5 };
int[] popOp = { 5, 4, 3, 2, 1 };

if (VerifySession(pushOp, popOp)) Console.WriteLine("Session Success");
else Console.WriteLine("Session at Fault");

// Negative Case
int[] pushOp2 = { 6, 7, 8, 9, 10 };
int[] popOp2 = { 8, 10, 7, 9 };

if (VerifySession(pushOp2, popOp2)) Console.WriteLine("Session Success");
else Console.WriteLine("Session at Fault");
