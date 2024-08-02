namespace EstudoGodot.Scripts.Interfaces
{
    public interface IArma
    {
        public int Dano { get; set; }
        public string Nome { get; set; }
        public float IntervaloAtaque { get; set; }
        public string Icone { get; set; }

        public void Atacar();
    }
}