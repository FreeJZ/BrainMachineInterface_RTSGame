using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class SetCommandPanel : PanelBase,IInvoker
{
    [Header("选择指令的按键")]
    public RectTransform cmdBtnFather;
    public Button atkBtn;
    public Button defenceBtn;
    public Button backBtn;
    public Button yuHuiBtn;
    public Button checkBtn;
    
    [Header("选择转换条件的按键")]
    public RectTransform tslBtnFather;
    public Transform scollViewContainer;

    public Text tipContent;
    [Header("选择面板Tweener参数")]
    public float yStart;
    public float yEnd;
    public float optionsShowDuratoin;

    public Button backCmdBtn;
    public Button nextCmdBtn;

    [HideInInspector] public E_Command firstCmd;
    [HideInInspector] public E_Command secondCmd;
    [HideInInspector] public int fristCmd2SecondCmdFlag;
    [HideInInspector] public int secondCmd2FristCmdFlag;
    [HideInInspector] public int searchPath2FcFlag;
    [HideInInspector] public int fc2SearchPathFlag;
    [HideInInspector] public int sreachPath2ScFlag;
    [HideInInspector] public int Sc2SreachPathFlag;

    List<ComandBase> IInvoker.CmdList { get; set; }
    int IInvoker.curIndex { get; set; }
    Stack<int> IInvoker.undoStack { get; set; }
    Stack<int> IInvoker.redoStack { get; set; }

    private IInvoker asInvoker;
    protected override void Awake()
    {
        base.Awake();

        backCmdBtn.onClick.AddListener(() =>
        {
            ToLastCmd();
        }); 
        nextCmdBtn.onClick.AddListener(() =>
        {
            ToNextCmd();
        });

        asInvoker = this as IInvoker;
        asInvoker.Init();

        //添加命令
        AddCmd(new SelectCmd1(this));
        AddCmd(new SelectCmd2(this));
        //AddCmd(new SelectTsl_SreachPath2FirstCmd(this));
        //AddCmd(new SelectTsl_FirstCmd2SreachPath(this));
        AddCmd(new SelectTsl_FirstCmd2SecondCmd(this));
        AddCmd(new SelectTsl_SecondCmd2FirstCmd(this));
        //AddCmd(new SelectTsl_SreachPath2SecondCmd(this));
        //AddCmd(new SelectTsl_SecondCmd2SreachPath(this));
    }

    private void Start()
    {
        yStart = tslBtnFather.position.y;
        asInvoker.ChangeNextCmd();
    }
    protected override void Update()
    {
        base.Update();
        if(asInvoker.Exute())
        {
            //设置兵种指令
            if(Input.GetKeyDown(KeyCode.Space))
            {
                List<ArmBase> arms = SelectionObjMgr.Instance.ArmBaseList;
                ResOperationMgr.Instance.AddTeam(firstCmd, secondCmd, fristCmd2SecondCmdFlag, secondCmd2FristCmdFlag, arms.ToArray());
                SelectionObjMgr.Instance.Clear();
            }
            //切换面板
            Debug.Log("命令执行完成，切换面板");
        }
    }

    private void ToLastCmd()
    {
        asInvoker.Undo();
    }

    private void ToNextCmd()
    {
        asInvoker.Redo();
    }

    private void AddCmd(ComandBase cmd)
    {
        asInvoker.AddCmd(cmd);
    }

}

//与该面板有关的命令

public class SelectCmd1 : ComandBase
{
    private SetCommandPanel panel;
    private bool havaBtnClick;
    public SelectCmd1(SetCommandPanel panel)
    {
        this.panel = panel;
    }

    public override void Enter()
    {
        panel.atkBtn.onClick.AddListener(AtkBtnEvent);
        panel.defenceBtn.onClick.AddListener(DefenceBtnEvent);
        panel.backBtn.onClick.AddListener(BackBtnEvent);
        panel.checkBtn.onClick.AddListener(CheckBtnEvent);
        panel.yuHuiBtn.onClick.AddListener(YuHuiBtnEvent);
        panel.cmdBtnFather.DOMoveY(panel.yEnd, panel.optionsShowDuratoin);
        panel.tipContent.text = "选择第一指令";
    }

    public override bool Excute()
    {
        return havaBtnClick;
    }

    public override void Exit(UnityAction action)
    {
        panel.atkBtn.onClick.RemoveListener(AtkBtnEvent);
        panel.defenceBtn.onClick.RemoveListener(DefenceBtnEvent);
        panel.backBtn.onClick.RemoveListener(BackBtnEvent);
        panel.checkBtn.onClick.RemoveListener(CheckBtnEvent);
        panel.yuHuiBtn.onClick.RemoveListener(YuHuiBtnEvent);
        panel.cmdBtnFather.DOMoveY(panel.yStart, panel.optionsShowDuratoin).OnComplete(()=>
        {
            action();
        });
        panel.tipContent.text = "";
        havaBtnClick = false;
    }

    private void AtkBtnEvent()
    {
        panel.firstCmd = E_Command.rush;
        havaBtnClick = true;
    }

    private void DefenceBtnEvent()
    {
        panel.firstCmd = E_Command.defence;
        havaBtnClick = true;
    }

    private void BackBtnEvent()
    {
        panel.firstCmd = E_Command.back;
        havaBtnClick = true;
    }

    private void YuHuiBtnEvent()
    {
        panel.firstCmd = E_Command.yuhui;
        havaBtnClick = true;
    }
    private void CheckBtnEvent()
    {
        panel.firstCmd = E_Command.check;
        havaBtnClick = true;
    }
}

public class SelectCmd2 : ComandBase
{
    private SetCommandPanel panel;
    private bool havaBtnClick;
    public SelectCmd2(SetCommandPanel panel)
    {
        this.panel = panel;
    }

    public override void Enter()
    {
        panel.atkBtn.onClick.AddListener(AtkBtnEvent);
        panel.defenceBtn.onClick.AddListener(DefenceBtnEvent);
        panel.backBtn.onClick.AddListener(BackBtnEvent);
        panel.checkBtn.onClick.AddListener(CheckBtnEvent);
        panel.yuHuiBtn.onClick.AddListener(YuHuiBtnEvent);
        panel.cmdBtnFather.DOMoveY(panel.yEnd, panel.optionsShowDuratoin);
        panel.tipContent.text = "选择第二指令";
    }

    public override bool Excute()
    {
        return havaBtnClick;
    }

    public override void Exit(UnityAction action)
    {
        panel.atkBtn.onClick.RemoveListener(AtkBtnEvent);
        panel.defenceBtn.onClick.RemoveListener(DefenceBtnEvent);
        panel.backBtn.onClick.RemoveListener(BackBtnEvent);
        panel.checkBtn.onClick.RemoveListener(CheckBtnEvent);
        panel.yuHuiBtn.onClick.RemoveListener(YuHuiBtnEvent);
        panel.cmdBtnFather.DOMoveY(panel.yStart, panel.optionsShowDuratoin).OnComplete(() =>
        {
            action();
        });
        panel.tipContent.text = "";
        havaBtnClick = false;
    }

    private void AtkBtnEvent()
    {
        panel.secondCmd = E_Command.rush;
        havaBtnClick = true;
    }

    private void DefenceBtnEvent()
    {
        panel.secondCmd = E_Command.defence;
        havaBtnClick = true;
    }

    private void BackBtnEvent()
    {
        panel.secondCmd = E_Command.back;
        havaBtnClick = true;
    }

    private void YuHuiBtnEvent()
    {
        panel.secondCmd = E_Command.yuhui;
        havaBtnClick = true;
    }
    private void CheckBtnEvent()
    {
        panel.secondCmd = E_Command.check;
        havaBtnClick = true;
    }
}

public abstract class SelectTranslationBaseCmd : ComandBase
{
    protected SetCommandPanel panel;
    private bool havaBtnClick;
    public SelectTranslationBaseCmd(SetCommandPanel panel)
    {
        this.panel = panel;    
    }
    public override void Enter()
    {

        //读取配置数据
        TslData data = ReadData(out E_Command fromCmd);
        //生成按钮
        for (int i = 0; i < data.pairsList.Count; i++)
        {
            Pair pair = data.pairsList[i];
            
            E_CmdType cmdType = panel.firstCmd == fromCmd ? E_CmdType.fristCmd : E_CmdType.SecondCmd;

            if (cmdType != pair.cmdType) continue; 

            GameObject obj = GameObjFactory.Instance.GetItem(ResPathConfig.UIPrefabPath + "TslBtn");

            TslBtnInfo tslBtnInfo = obj.GetComponent<TslBtnInfo>();
            tslBtnInfo.Init(pair.tip, pair.flag);
            
            obj.transform.SetParent(panel.scollViewContainer, false);

            //注册点击事件
            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                TslBtnInfo info = tslBtnInfo;
                BtnClickEvent(info.MapFlag);
            });
        }
        panel.tslBtnFather.DOMoveY(panel.yEnd, panel.optionsShowDuratoin);
    }

    public override bool Excute()
    {
        return havaBtnClick;
    }

    public override void Exit(UnityAction action)
    {
        //删除按钮
        Button[] btns = panel.scollViewContainer.GetComponentsInChildren<Button>();
        for(int i = 0;i<btns.Length;i++)
        {
            GameObject.Destroy(btns[i].gameObject);
        }
        panel.tslBtnFather.DOMoveY(panel.yStart, panel.optionsShowDuratoin).OnComplete(() =>
        {
            action();
        });
        havaBtnClick = false;
    }

    //重写赋值panel的flag值
    protected virtual void BtnClickEvent(int flag)
    { 
        havaBtnClick = true;
    }

    protected abstract TslData ReadData(out E_Command fromCmd);

}

public class SelectTsl_SreachPath2FirstCmd : SelectTranslationBaseCmd
{
    public SelectTsl_SreachPath2FirstCmd(SetCommandPanel panel) : base(panel)
    {
    }

    public override void Enter()
    {
        base.Enter();
        panel.tipContent.text = "选择寻路到第一指令的转换";
    }

    protected override TslData ReadData(out E_Command fromCmd)
    {
        fromCmd = E_Command.sreachPath;
        return DataMgr.Instance.GetTslData(E_Command.sreachPath, panel.firstCmd);
    }
    protected override void BtnClickEvent(int flag)
    {
        base.BtnClickEvent(flag);
        panel.searchPath2FcFlag = flag;
    }
}

public class SelectTsl_FirstCmd2SreachPath : SelectTranslationBaseCmd
{
    public SelectTsl_FirstCmd2SreachPath(SetCommandPanel panel) : base(panel)
    {
    }
    public override void Enter()
    {
        base.Enter();
        panel.tipContent.text = "选择第一指令到寻路的转换";
    }

    protected override TslData ReadData(out E_Command fromCmd)
    {
        fromCmd = panel.firstCmd;
        return DataMgr.Instance.GetTslData(panel.firstCmd,E_Command.sreachPath);
    }
    protected override void BtnClickEvent(int flag)
    {
        base.BtnClickEvent(flag);
        panel.fc2SearchPathFlag = flag;
    }
}

public class SelectTsl_FirstCmd2SecondCmd : SelectTranslationBaseCmd
{
    public SelectTsl_FirstCmd2SecondCmd(SetCommandPanel panel) : base(panel)
    {
    }
    public override void Enter()
    {
        base.Enter();
        panel.tipContent.text = $"选择{panel.firstCmd}到{panel.secondCmd}的转换";
    }
    protected override TslData ReadData(out E_Command fromCmd)
    {
        fromCmd = panel.firstCmd;
        return DataMgr.Instance.GetTslData(panel.firstCmd, panel.secondCmd);
    }
    protected override void BtnClickEvent(int flag)
    {
        base.BtnClickEvent(flag);
        panel.fristCmd2SecondCmdFlag = flag;
    }
}

public class SelectTsl_SecondCmd2FirstCmd: SelectTranslationBaseCmd
{
    public SelectTsl_SecondCmd2FirstCmd(SetCommandPanel panel) : base(panel)
    {
    }
    public override void Enter()
    {
        base.Enter();
        panel.tipContent.text = $"选择{panel.secondCmd}到{panel.firstCmd}的转换";
    }
    protected override TslData ReadData(out E_Command fromCmd)
    {
        fromCmd = panel.secondCmd;
        return DataMgr.Instance.GetTslData(panel.secondCmd, panel.firstCmd);
    }
    protected override void BtnClickEvent(int flag)
    {
        base.BtnClickEvent(flag);
        panel.secondCmd2FristCmdFlag = flag;
    }
}

public class SelectTsl_SreachPath2SecondCmd : SelectTranslationBaseCmd
{
    public SelectTsl_SreachPath2SecondCmd(SetCommandPanel panel) : base(panel)
    {
    }

    public override void Enter()
    {
        base.Enter();
        panel.tipContent.text = "选择寻路到第二指令的转换";
    }
    protected override TslData ReadData(out E_Command fromCmd)
    {
        fromCmd = E_Command.sreachPath;
        return DataMgr.Instance.GetTslData(E_Command.sreachPath, panel.secondCmd);
    }
    protected override void BtnClickEvent(int flag)
    {
        base.BtnClickEvent(flag);
        panel.sreachPath2ScFlag = flag;
    }
}

public class SelectTsl_SecondCmd2SreachPath : SelectTranslationBaseCmd
{
    public SelectTsl_SecondCmd2SreachPath(SetCommandPanel panel) : base(panel)
    {
    }
    public override void Enter()
    {
        base.Enter();
        panel.tipContent.text = "选择第二指令到寻路的转换";
    }
    protected override TslData ReadData(out E_Command fromCmd)
    {
        fromCmd = panel.secondCmd;
        return DataMgr.Instance.GetTslData( panel.secondCmd,E_Command.sreachPath);
    }
    protected override void BtnClickEvent(int flag)
    {
        base.BtnClickEvent(flag);
        panel.Sc2SreachPathFlag = flag;
    }
}