namespace ConsoleApp6;

public class MySort
{
    private List<int> _nums;
    
    public List<int> getNums()
    {
        return _nums;
    }
    
    public MySort(List<int> nums)
    {
        _nums = nums;
    }

    public void QuickSort(int left, int right)
    {
        if (left < right)
        {
            int pivot = GetPivotSort(left, right);

            if (pivot > 1)
            {
                QuickSort(left, pivot - 1);
            }

            if (pivot + 1 < right)
            {
                QuickSort(pivot + 1, right);
            }
        }
    }

    private int GetPivotSort(int left, int right)
    {
        int pivot = _nums[left];
        while (true)
        {
            while (_nums[left] < pivot)
            {
                left++;
            }

            while (_nums[right] > pivot)
            {
                right--;
            }

            if (left < right)
            {
                if (_nums[left] == _nums[right]) return right;
                
                (_nums[left], _nums[right]) = (_nums[right], _nums[left]);
            }
            else
            {
                return right;
            }
        }
    }
}