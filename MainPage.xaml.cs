namespace mauiCalculator;

public partial class MainPage : ContentPage
{
	int currentState = 1;
    string operatorMath;
    double firstNum, secondNum;

    public MainPage()
	{
		InitializeComponent();
        OnClear(this, null);
	}

	void OnClear(object sender, EventArgs e)
    {
        firstNum = 0;
        secondNum = 0;
        currentState = 1;
        this.result.Text = "0";
    }
    void OnClearError(object sender, EventArgs e)
    {
        secondNum = 0;
        currentState = 1;
        this.result.Text = "0";
        Console.WriteLine("first : "+firstNum);
    }
    void OnPercent(object sender, EventArgs e)
    {
        if (firstNum == 0)
            return;
        firstNum = firstNum / 100;
        this.result.Text = firstNum.ToString();
    }
    void OnNegative(object sender, EventArgs e)
    {
        if (firstNum == 0)
            return;
        firstNum = firstNum * -1;
        this.result.Text = firstNum.ToString();
    }

    void OnNumberSelection(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string btnPressed = button.Text;

        if (this.result.Text == "0" || currentState < 0)
        {
            this.result.Text = string.Empty;
            if (currentState < 0)
                currentState *= -1;
        }

        this.result.Text += btnPressed;

        double number;
        if (double.TryParse(this.result.Text, out number))
        {
            //this.result.Text = number.ToString("NO");
            if (currentState == 1)
            {
                firstNum = number;
            }
            else
            {
                secondNum = number;
            }
        }

    }

    void onOperatorSelection(object sender, EventArgs e)
    {
        currentState = -2;
        Button button = (Button)sender;
        string btnPressed = button.Text;
        operatorMath = btnPressed;
    }

    void onCalculate(object sender, EventArgs e)
    {
        if(currentState == 2)
        {
            var result = Calculate.Calculer(firstNum, secondNum, operatorMath);
            this.result.Text = result.ToString();
            firstNum = result;
            currentState = -1;

        }
    }



    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;

    //	if (count == 1)
    //		CounterBtn.Text = $"Clicked {count} time";
    //	else
    //		CounterBtn.Text = $"Clicked {count} times";

    //	SemanticScreenReader.Announce(CounterBtn.Text);
    //}
}


