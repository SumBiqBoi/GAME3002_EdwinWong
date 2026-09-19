public class Upgrades
{
    public float currentEnergy;
    public float maxEnergy;

    public int coinsHeld;

    public float mass;
    public float acceleration;
    public float maxSpeed;
    public float rotateSpeed;

    public float containerStrength;

    public void Init()
    {
        currentEnergy = 10;
        maxEnergy = 100;
        coinsHeld = 25;
        mass = 1;
        acceleration = 20;
        maxSpeed = 4; 
        rotateSpeed = 150;
        containerStrength = 0;
    }

    public float GetCurrentEnergy()
    {
        return currentEnergy;
    }

    public void SetCurrentEnergy(float value)
    {
        currentEnergy += value;
    }

    public float GetMaxEnergy()
    { 
        return maxEnergy; 
    }

    public void SetMaxEnergy(float value)
    {
        maxEnergy += value;
    }

    public int GetCoinsHeld()
    {
        return coinsHeld;
    }

    public void SetCoinsHeld(int value)
    {
        coinsHeld += value;
    }

    public float GetMass()
    {
        return mass;
    }

    public void SetMass(float value)
    {
        mass += value;
    }

    public float GetAcceleration()
    {
        return acceleration;
    }

    public void SetAcceleration(float value)
    {
        acceleration += value;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

    public void SetMaxSpeed(float value)
    {
        maxSpeed += value;
    }

    public float GetRotateSpeed()
    {
        return rotateSpeed;
    }

    public void SetRotateSpeed(float value)
    {
        rotateSpeed += value;
    }

    public float GetContainerStrength()
    {
        return containerStrength;
    }

    public void SetContainerStrength(float value)
    {
        containerStrength += value;
    }
}
