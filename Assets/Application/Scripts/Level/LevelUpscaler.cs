using UnityEngine;

public class LevelUpscaler
{
    private int maxColCount = 12;
    private int maxMinesCount = 4;
    
    public int RowCount
    {
        get
        {
            var rows = 5;
            
            return rows;
        }
    }

    public int ColCount
    {
        get
        {
            var cols = 6;
            var level = PlayerPrefs.GetInt("Level", 1);
            
            for (int i = 1; i < level; i++)
            {
                if (cols < maxColCount)
                    cols++;
            }
            
            return cols;
        }
    }

    public int MineCount
    {
        get
        {
            var mines = 1;
            var level = PlayerPrefs.GetInt("Level", 1);
            
            for (int i = 1; i < level; i++)
            {
                if (ColCount == maxColCount && mines < maxMinesCount)
                    mines++;
            }
            
            return mines;
        }
    }
}
