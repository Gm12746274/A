# PC Optimizer 300 (C#)

Projeto em **C# (console)** com um menu de **300 opções** para otimização e manutenção de PC, pensado para quem não usa Visual Studio.

## Requisitos

- Windows 10/11
- PowerShell
- (Opcional) Git
- `.NET SDK 8.0` (os scripts `.bat` tentam instalar automaticamente)

## Como usar sem Visual Studio

1. Clique duas vezes em `deps.bat` para instalar dependências.
2. Clique duas vezes em `build.bat` para gerar o `.exe`.
3. O executável final será criado em:
   - `publish\PcOptimizer300.exe`

## Execução no modo desenvolvimento

```bat
run.bat
```

## Observações importantes

- O app pede confirmação antes de executar ações que alteram o sistema.
- Muitas opções são templates prontos para expansão (todas as 300 opções existem no menu).
- Algumas ações exigem **Administrador**.

