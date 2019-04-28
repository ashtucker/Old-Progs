unit main_work;

{$mode objfpc}{$H+}

interface

type
  TMainProgram = class
    type
      boolArray = Array[0..32000] of Boolean;
      boolArrays = Array[1..3] of boolArray;

    private
      n:Integer;
      inputBoolArrays:boolArrays;
      poweredTwo:DWord;
      resultedNumber:Integer;

      procedure GenerateBoolArrays();
      function ConvertToDecimal(binaryNumber:boolArray): Integer;
      function ModuleSum(firstBinaryNum, secondBinaryNum:boolArray): boolArray;
      function ModuleSub(firstBinaryNum, secondBinaryNum:boolArray): boolArray;
      function InverseBooleans(binaryNum:boolArray): boolArray;
      function InverseBooleans(decimalNum:Integer): boolArray;
      procedure DoFunction();
      procedure Print(input:Boolean);

    public
      constructor create(inputN:Integer);
      procedure DoWork();
      function ConvertToBinary(decimalNum:Integer): boolArray;
  end;


implementation
  uses math;
  constructor TMainProgram.create(inputN:Integer);
  begin
    n:= inputN;
    GenerateBoolArrays();
    poweredTwo:= Trunc(Power(2, n));
    Print(True);
  end;

  procedure TMainProgram.GenerateBoolArrays();
  var
    i:Byte;
    j:Integer;
  begin
    Randomize();
    for i:=1 to 3 do
      for j:=0 to n do
        begin
        if (Random(2) = 0) then
          inputBoolArrays[i][j]:= False
        else
          inputBoolArrays[i][j]:= True;
        end;
  end;

  function TMainProgram.ConvertToDecimal(binaryNumber:boolArray): Integer;
  var
    i:Integer;
    decimalNum:Integer;
  begin
    decimalNum:=0;
    for i:=1 to n do
      if (binaryNumber[i]) then
        decimalNum:= decimalNum + Trunc(Power(2, n - i));

    if not binaryNumber[0] then
      decimalNum:= decimalNum * -1;

    ConvertToDecimal:= decimalNum;
  end;

  function TMainProgram.ModuleSum(firstBinaryNum, secondBinaryNum:boolArray): boolArray;
  var
    a,b:Integer;
  begin
    a:= ConvertToDecimal(firstBinaryNum);
    b:= ConvertToDecimal(secondBinaryNum);

    ModuleSum:= ConvertToBinary((a + b) mod poweredTwo);
  end;

  function TMainProgram.InverseBooleans(binaryNum:boolArray): boolArray;
  var
    i:Integer;
  begin
    for i:=0 to n do
      binaryNum[i]:= not binaryNum[i];

    InverseBooleans:= binaryNum;
  end;

  function TMainProgram.ConvertToBinary(decimalNum:Integer): boolArray;
  var
    resultBinary:boolArray;
    tempBinary:boolArray;
    i, j:Integer;
  begin
    for j:=0 to 32000 do
      tempBinary[j]:=False;

    if (decimalNum > 0) then
      resultBinary[0]:= True
    else
    begin
      resultBinary[1]:= False;
      decimalNum:= decimalNum * -1;
    end;

    i:=0;

    while (decimalNum > 0) do
    begin
      Inc(i);
      if (decimalNum mod 2 = 0) then
        tempBinary[i]:=False
      else
        tempBinary[i]:=True;
      decimalNum:= decimalNum div 2;
    end;

    for j:=1 to n do
      resultBinary[j]:= tempBinary[n - j + 1];

    ConvertToBinary:=resultBinary;
  end;

  function TMainProgram.InverseBooleans(decimalNum:Integer): boolArray;
  begin
    InverseBooleans:=InverseBooleans(ConvertToBinary(decimalNum));
  end;

  function TMainProgram.ModuleSub(firstBinaryNum, secondBinaryNum:boolArray): boolArray;
  begin
    secondBinaryNum[0]:= not secondBinaryNum[0];
    ModuleSub:= ModuleSum(firstBinaryNum, secondBinaryNum);
  end;

  procedure TMainProgram.DoFunction();
  var
    firstSubResult, secondSubResult, thirdSubResult, fourthSubResult:boolArray;
  begin
    firstSubResult:= ModuleSub(ModuleSum(inputBoolArrays[1], inputBoolArrays[2]), InverseBooleans(inputBoolArrays[3]));
    secondSubResult:= ModuleSub(InverseBooleans(inputBoolArrays[1]), inputBoolArrays[2]);
    thirdSubResult:= InverseBooleans(ModuleSub(inputBoolArrays[1], inputBoolArrays[2]));
    fourthSubResult:= ModuleSub(inputBoolArrays[2], inputBoolArrays[3]);

    resultedNumber:= ConvertToDecimal(ModuleSum(firstSubResult, ModuleSub(ModuleSum(secondSubResult, thirdSubResult), fourthSubResult)));
  end;

  procedure TMainProgram.Print(input:Boolean);
  var
    i, j, h:Integer;
    temp:boolArray;
  begin
    if (input) then
      for i:=1 to 3 do
      begin
        for j:=0 to n do
          Write(inputBoolArrays[i][j], ' ');
        Write('= ', ConvertToDecimal(inputBoolArrays[i]), ' -> ');
        temp:= ConvertToBinary(ConvertToDecimal(inputBoolArrays[i]));
        for h:=0 to n do
          Write(temp[h], ' ');
        WriteLn();
      end
    else
      WriteLn(resultedNumber);
  end;

  procedure TMainProgram.DoWork();
  begin
    DoFunction();
    Print(False);
  end;

end.

