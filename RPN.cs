using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RPN
{
    private static List<string> ParseRPN(string rpn) {
        string currentElement = "";
        List<string> rpnL = new List<string>();
        for (var i=0;i<rpn.Length;i++) {
            if (rpn[i].ToString()==" ") {
                rpnL.Add(currentElement);
                currentElement = "";
            } else {
                currentElement = currentElement+rpn[i];
            }
        }
        rpnL.Add(currentElement);
        return rpnL;
    }
    private static List<string> ParseRPN(string rpn,int[] prams) {
        string currentElement = "";
        List<string> rpnL = new List<string>();
        for (var i=0;i<rpn.Length;i++) {
            if (rpn[i].ToString()==" ") {
                if (currentElement[0].ToString()=="$") {
                    currentElement = prams[Int32.Parse(currentElement.Substring(1))].ToString();
                }
                rpnL.Add(currentElement);
                currentElement = "";
            } else {
                currentElement = currentElement+rpn[i];
            }
        }
        rpnL.Add(currentElement);
        return rpnL;
    }
    private static string EncodeRPN(List<string> rpn) {
        string resRPN = "";
        foreach (string rpnE in rpn) {
            resRPN = resRPN + rpnE + " ";
        }
        return resRPN;
    }
    ///<summary>
    ///<para>Calculates the Reversed Polish Notation (RPN) of an expression, with optional variable (pram) values.</para>
    ///<para>Notate variable values with $ and the index of the value.</para>
    ///<para>Ex:</para>
    ///<para>$1 where the prams are { 0,1,2 } gives 1.</para>
    ///<para>Operations: + - * /</para>
    ///<para>Number1 Operation Number2 => Number1 Number2 Operation</para>
    ///<para>(Number1 Operation1 Number2) Operation2 Number3 => Number1 Number2 Operation1 Number3 Operation2</para>
    ///<para>(Number1 Operation1 Number2) Operation2 (Number3 Operation3 Number4) => Number1 Number2 Operation1 Number3 Number4 Operation3 Operation4</para>
    ///<para></para>
    ///<para>Exs:</para>
    ///<para>1 + 1 => 1 1 + </para>
    ///<para>(1+1)*2 => 1 1 + 2 * </para>
    ///<para>(2/2)*(5+3) => 2 2 / 5 3 + * </para>
    ///</summary>
    public static int ReversedPolishNotation(string rpn,int limTimes=100) {
        List<string> rpnL = ParseRPN(rpn);
        var times = 0;
        do {
            times+=1;
            int pramsFound = 0;
            var i = 0;
            do {
                try {
                    Int32.Parse(rpnL[i]);
                    if (pramsFound<2) {
                        pramsFound+=1;
                    } else {
                        pramsFound=0;
                    }
                } catch {
                    if (pramsFound==2) {
                        if (rpnL[i]=="+") {
                            rpnL[i-2]=(Int32.Parse(rpnL[i-2])+Int32.Parse(rpnL[i-1])).ToString();
                        } else if (rpnL[i]=="-") {
                            rpnL[i-2]=(Int32.Parse(rpnL[i-2])-Int32.Parse(rpnL[i-1])).ToString();
                        } else if (rpnL[i]=="*") {
                            rpnL[i-2]=(Int32.Parse(rpnL[i-2])*Int32.Parse(rpnL[i-1])).ToString();
                        } else if (rpnL[i]=="/") {
                            rpnL[i-2]=(Int32.Parse(rpnL[i-2])/Int32.Parse(rpnL[i-1])).ToString();
                        }
                        rpnL.RemoveAt(i-1);
                        rpnL.RemoveAt(i-1);
                        pramsFound=0;
                        i-=2;
                    } else {
                        pramsFound=0;
                    }
                }
                i+=1;
            } while (i<rpnL.Count);
        } while (rpnL.Count>1 && times<limTimes);
        if (times<limTimes) {
            return Int32.Parse(rpnL[0]);
        } else {
            return -1;
        }
    }
    ///<summary>
    ///<para>Calculates the Reversed Polish Notation (RPN) of an expression, with optional variable (pram) values. Remember to add a space after the RPN.</para>
    ///<para>Notate variable values with $ and the index of the value.</para>
    ///<para>Ex:</para>
    ///<para>$1 where the prams are { 0,1,2 } gives 1.</para>
    ///<para>Operations: + - * /</para>
    ///<para>Number1 Operation Number2 => Number1 Number2 Operation</para>
    ///<para>(Number1 Operation1 Number2) Operation2 Number3 => Number1 Number2 Operation1 Number3 Operation2</para>
    ///<para>(Number1 Operation1 Number2) Operation2 (Number3 Operation3 Number4) => Number1 Number2 Operation1 Number3 Number4 Operation3 Operation4</para>
    ///<para></para>
    ///<para>Exs:</para>
    ///<para>1 + 1 => 1 1 + </para>
    ///<para>(1+1)*2 => 1 1 + 2 * </para>
    ///<para>(2/2)*(5+3) => 2 2 / 5 3 + * </para>
    ///</summary>
    public static int ReversedPolishNotation(string rpn,int[] prams,int limTimes=100) {
        List<string> rpnL = ParseRPN(rpn,prams);
        var times = 0;
        do {
            times+=1;
            int pramsFound = 0;
            var i = 0;
            do {
                try {
                    Int32.Parse(rpnL[i]);
                    if (pramsFound<2) {
                        pramsFound+=1;
                    } else {
                        pramsFound=0;
                    }
                } catch {
                    if (pramsFound==2) {
                        if (rpnL[i]=="+") {
                            rpnL[i-2]=(Int32.Parse(rpnL[i-2])+Int32.Parse(rpnL[i-1])).ToString();
                        } else if (rpnL[i]=="-") {
                            rpnL[i-2]=(Int32.Parse(rpnL[i-2])-Int32.Parse(rpnL[i-1])).ToString();
                        } else if (rpnL[i]=="*") {
                            rpnL[i-2]=(Int32.Parse(rpnL[i-2])*Int32.Parse(rpnL[i-1])).ToString();
                        } else if (rpnL[i]=="/") {
                            rpnL[i-2]=(Int32.Parse(rpnL[i-2])/Int32.Parse(rpnL[i-1])).ToString();
                        }
                        rpnL.RemoveAt(i-1);
                        rpnL.RemoveAt(i-1);
                        pramsFound=0;
                        i-=2;
                    } else {
                        pramsFound=0;
                    }
                }
                i+=1;
            } while (i<rpnL.Count && times<limTimes);
        } while (rpnL.Count>1);
        if (times<limTimes) {
            return Int32.Parse(rpnL[0]);
        } else {
            return -1;
        }
    }
}
