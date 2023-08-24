using System.Collections.Generic;

public interface INode{
    int gCost();
    int hCost();
    int fCost();

    bool accessible();
    bool occupied();
    string nodeProperties();
    
}