using Kogane;
using System.Linq;
using System.Text;
using UnityEngine;

public sealed class UIRebuildCheckerBehaviour : MonoBehaviour
{
    private void Update()
    {
        var list = UIRebuildChecker.Check();

        if ( list.Count <= 0 ) return;

        var sb = new StringBuilder();

        sb.Append( "合计：" );
        sb.Append( list.GroupBy( x => x.Canvas ).Sum( x => x.First().RebuildTargets.Count ).ToString() );
        sb.AppendLine();
        sb.AppendLine();
        sb.AppendLine( "详细" );
        sb.AppendLine();

        foreach ( var rebuildData in list )
        {
            sb.Append( "UI Name：" );
            sb.Append( rebuildData.Graphic.name );
            sb.AppendLine();

            sb.Append( "所属Canvas：" );
            sb.Append( rebuildData.Canvas.name );
            sb.AppendLine();

            sb.Append( "属于Canvas的对象数：" );
            sb.Append( rebuildData.RebuildTargets.Count.ToString() );
            sb.AppendLine();

            sb.AppendLine();
        }

        var text = sb.ToString();

        Debug.Log( text );
    }
}