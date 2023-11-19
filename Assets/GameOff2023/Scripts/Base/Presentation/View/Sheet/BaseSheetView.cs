using System.Collections;
using UnityScreenNavigator.Runtime.Core.Sheet;

namespace GameOff2023.Base.Presentation.View
{
    public abstract class BaseSheetView : Sheet
    {
        protected IEnumerator ShowSheetCor(string resourceKey)
        {
            var sheetContainer = SheetContainer.Of(transform);

            // 任意のSheetのインスタンス生成
            if (sheetContainer.Sheets.ContainsKey(resourceKey) == false)
            {
                yield return sheetContainer.Register(resourceKey, sheetId: resourceKey);
            }

            // 任意のSheetを表示
            yield return sheetContainer.Show(resourceKey, true);
        }
    }
}