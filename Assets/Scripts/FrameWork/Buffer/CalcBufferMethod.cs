using UnityEngine;

public class CalcBufferMethod : IStrategy<BufferBase, BufferBase, ArmBase>
{
    public void Handle(BufferBase buffer1, BufferBase buffer2, ArmBase obj)
    {
        if (buffer1 == null || buffer2 == null || obj == null) Debug.LogError("参数为NULL");
        if(buffer1 == buffer2)
        {
            obj.hp *= SameBufferCalc(buffer1.hpGian);
            obj.atkVal *= SameBufferCalc(buffer1.atkValGain);
            obj.atkSpeed *= SameBufferCalc(buffer1.atkSpeedGain);
            obj.atkDis *= SameBufferCalc(buffer1.atkDisGain);
            obj.moveSpeed *= SameBufferCalc(buffer1.moveSpeedGain);
        }
        else
        {
            obj.hp *= DiffBufferCalc(buffer1.hpGian,buffer2.hpGian);
            obj.atkVal *= DiffBufferCalc(buffer1.atkValGain, buffer2.atkValGain);
            obj.atkSpeed *= DiffBufferCalc(buffer1.atkSpeedGain, buffer2.atkSpeedGain);
            obj.atkDis *= DiffBufferCalc(buffer1.atkDisGain, buffer2.atkDisGain);
            obj.moveSpeed *= DiffBufferCalc(buffer1.moveSpeedGain, buffer2.moveSpeedGain);
        }
    }

    private float SameBufferCalc(float val)
    {
        return val * val + val;
    }

    private float DiffBufferCalc(float val1, float val2)
    {
        return Mathf.Max(val1, val2)/2;
    }
}