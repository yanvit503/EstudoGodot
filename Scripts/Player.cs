using Godot;

public partial class Player : CharacterBody2D
{
    public const float Velocidade = 100.0f;
    private AnimatedSprite2D animatedSprite;

    public static Player Instance;

    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        Instance = this;
    }

    public override void _PhysicsProcess(double delta)
    {
        float velocidadeX = Input.GetActionStrength("Direita") - Input.GetActionStrength("Esquerda");
        float velocidadeY = Input.GetActionStrength("Baixo") - Input.GetActionStrength("Cima");

        Velocity = new Vector2(velocidadeX, velocidadeY).Normalized() * Velocidade;

        MoveAndSlide();

        UpdateAnimation(velocidadeX, velocidadeY);
    }

    private void UpdateAnimation(float velocidadeX, float velocidadeY)
    {
        if (!ArmasController.Instance.atacando)
        {
            if (velocidadeX > 0 || velocidadeX < 0)
                animatedSprite.Play("Andar");
            else
            {
                if (velocidadeY > 0)
                    animatedSprite.Play("Andar_Baixo");
                else if (velocidadeY < 0)
                    animatedSprite.Play("Andar_Cima");
            } 
        }

        animatedSprite.FlipH = velocidadeX < 0;

        if (velocidadeX == 0 && velocidadeY == 0 && !ArmasController.Instance.atacando)
            animatedSprite.Play("Idle");
    }

    public void AnimacaoAtaqueMelee()
    {
        animatedSprite.Stop();
        animatedSprite.Play("Ataque_Melee");
    }
}