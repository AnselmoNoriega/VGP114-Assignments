namespace WorldEditor;

public class WorldEditorProgram
{
    CreateCommand gobLab1 = new CreateCommand(eEntityType.GoblinLaboratory, 5, 3);
    CreateCommand goldMine1 = new CreateCommand(eEntityType.GoldMine, 5, 3);

    public void Run()
    {
        HistoryManager.GetInstance.ExecuteCmd(gobLab1);

        HistoryManager.GetInstance.ExecuteCmd(goldMine1);

        HistoryManager.GetInstance.Map();

        PlaceCommand.GetInstance.SetOldPos(5, 3);
        PlaceCommand.GetInstance.SetNewPos(2, 1);
        HistoryManager.GetInstance.ExecuteCmd(PlaceCommand.GetInstance);

        HistoryManager.GetInstance.Map();

        HistoryManager.GetInstance.UndoCmd();
        HistoryManager.GetInstance.UndoCmd();
        HistoryManager.GetInstance.UndoCmd();

        HistoryManager.GetInstance.RedoCmd();
        HistoryManager.GetInstance.RedoCmd();

        HistoryManager.GetInstance.ExecuteCmd(goldMine1);

        DeleteCommand firstdel = new DeleteCommand(5, 3);

        HistoryManager.GetInstance.ExecuteCmd(firstdel);
        HistoryManager.GetInstance.UndoCmd();
        HistoryManager.GetInstance.ExecuteCmd(firstdel);
        HistoryManager.GetInstance.UndoCmd();

        HistoryManager.GetInstance.Map();

    }
}
