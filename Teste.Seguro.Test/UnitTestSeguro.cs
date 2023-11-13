namespace Teste.Seguro.Test;

[TestClass]
public class UnitTestSeguro
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual(1, 1);
    }

    [TestMethod]
    public void TestCalculate()
    {
        //var entity = new SeguroEntity(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 0);

        //var mock = new Mock<ISeguroRepository<SeguroEntity>>();
        //mock.Setup(x => x.Calcular(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns(("somar", 7.7));

        //var maqCalc = new SeguroService(mock.Object);
        //(string operacao, double resultado) op = maqCalc.CalcularSeguro(entity);

        //Assert.Equals("somar", op.operacao);
        //Assert.Equals(7.7, op.resultado);
    }
}