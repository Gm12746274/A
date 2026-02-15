using System.Diagnostics;

var options = BuildOptions();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== PC Optimizer 300 ===");
    Console.WriteLine("Escolha uma opção (1-300) ou 0 para sair:\n");

    for (var i = 0; i < options.Count; i++)
    {
        Console.WriteLine($"{options[i].Id,3}. {options[i].Title}");
    }

    Console.Write("\nOpção: ");
    if (!int.TryParse(Console.ReadLine(), out var choice))
    {
        Console.WriteLine("Entrada inválida. Pressione ENTER...");
        Console.ReadLine();
        continue;
    }

    if (choice == 0)
    {
        break;
    }

    var selected = options.FirstOrDefault(o => o.Id == choice);
    if (selected is null)
    {
        Console.WriteLine("Opção fora do intervalo. Pressione ENTER...");
        Console.ReadLine();
        continue;
    }

    Console.WriteLine($"\n[{selected.Id}] {selected.Title}");
    Console.WriteLine(selected.Description);

    if (string.IsNullOrWhiteSpace(selected.Command))
    {
        Console.WriteLine("Ação modelo cadastrada. Personalize este item no código se quiser automatizar.");
        Console.WriteLine("Pressione ENTER para voltar ao menu...");
        Console.ReadLine();
        continue;
    }

    Console.Write("Executar agora? (s/N): ");
    var confirm = Console.ReadLine()?.Trim().ToLowerInvariant();
    if (confirm != "s" && confirm != "sim")
    {
        continue;
    }

    RunCommand(selected.Command);
    Console.WriteLine("\nConcluído. Pressione ENTER para continuar...");
    Console.ReadLine();
}

static List<OptimizerOption> BuildOptions()
{
    var options = new List<OptimizerOption>
    {
        new OptimizerOption(1, "Limpar arquivos temporários do usuário", "Remove arquivos temporários em %TEMP%.", "cmd /c del /q /f /s %TEMP%\*"),
        new OptimizerOption(2, "Limpar cache de DNS", "Renova resolução de nomes na rede.", "ipconfig /flushdns"),
        new OptimizerOption(3, "Checar integridade do sistema (SFC)", "Executa sfc /scannow (admin recomendado).", "sfc /scannow"),
        new OptimizerOption(4, "Reparar imagem do Windows (DISM)", "Executa DISM /RestoreHealth (admin recomendado).", "DISM /Online /Cleanup-Image /RestoreHealth"),
        new OptimizerOption(5, "Verificar disco (CHKDSK leitura)", "Checa erros no disco sem reparo automático.", "chkdsk"),
        new OptimizerOption(6, "Desativar hibernação", "Desliga hibernação para liberar espaço.", "powercfg -h off"),
        new OptimizerOption(7, "Ativar hibernação", "Liga hibernação novamente.", "powercfg -h on"),
        new OptimizerOption(8, "Abrir Gerenciador de Tarefas", "Atalho rápido para o taskmgr.", "taskmgr"),
        new OptimizerOption(9, "Abrir Limpeza de Disco", "Executa cleanmgr.", "cleanmgr"),
        new OptimizerOption(10, "Listar programas na inicialização", "Abre pasta Startup do usuário.", "explorer shell:startup"),
        new OptimizerOption(11, "Abrir Apps e Recursos", "Atalho para desinstalar programas.", "start ms-settings:appsfeatures"),
        new OptimizerOption(12, "Abrir Configurações de Armazenamento", "Atalho para Storage Sense.", "start ms-settings:storagesense"),
        new OptimizerOption(13, "Abrir Configurações de Energia", "Atalho para plano de energia.", "start ms-settings:powersleep"),
        new OptimizerOption(14, "Escanear malware com MRT", "Roda ferramenta nativa do Windows.", "mrt"),
        new OptimizerOption(15, "Listar drivers instalados", "Mostra drivers no terminal.", "driverquery"),
        new OptimizerOption(16, "Atualizar políticas de grupo", "Executa gpupdate /force.", "gpupdate /force"),
        new OptimizerOption(17, "Resetar stack de rede (Winsock)", "Executa netsh winsock reset.", "netsh winsock reset"),
        new OptimizerOption(18, "Resetar IP", "Executa netsh int ip reset.", "netsh int ip reset"),
        new OptimizerOption(19, "Mostrar informações do sistema", "Executa systeminfo.", "systeminfo"),
        new OptimizerOption(20, "Abrir monitor de recursos", "Executa resmon.", "resmon"),
        new OptimizerOption(21, "Otimização rápida #21", "Template de otimização #21: ajuste manual disponível para personalização.", null),
        new OptimizerOption(22, "Otimização rápida #22", "Template de otimização #22: ajuste manual disponível para personalização.", null),
        new OptimizerOption(23, "Otimização rápida #23", "Template de otimização #23: ajuste manual disponível para personalização.", null),
        new OptimizerOption(24, "Otimização rápida #24", "Template de otimização #24: ajuste manual disponível para personalização.", null),
        new OptimizerOption(25, "Otimização rápida #25", "Template de otimização #25: ajuste manual disponível para personalização.", null),
        new OptimizerOption(26, "Otimização rápida #26", "Template de otimização #26: ajuste manual disponível para personalização.", null),
        new OptimizerOption(27, "Otimização rápida #27", "Template de otimização #27: ajuste manual disponível para personalização.", null),
        new OptimizerOption(28, "Otimização rápida #28", "Template de otimização #28: ajuste manual disponível para personalização.", null),
        new OptimizerOption(29, "Otimização rápida #29", "Template de otimização #29: ajuste manual disponível para personalização.", null),
        new OptimizerOption(30, "Otimização rápida #30", "Template de otimização #30: ajuste manual disponível para personalização.", null),
        new OptimizerOption(31, "Otimização rápida #31", "Template de otimização #31: ajuste manual disponível para personalização.", null),
        new OptimizerOption(32, "Otimização rápida #32", "Template de otimização #32: ajuste manual disponível para personalização.", null),
        new OptimizerOption(33, "Otimização rápida #33", "Template de otimização #33: ajuste manual disponível para personalização.", null),
        new OptimizerOption(34, "Otimização rápida #34", "Template de otimização #34: ajuste manual disponível para personalização.", null),
        new OptimizerOption(35, "Otimização rápida #35", "Template de otimização #35: ajuste manual disponível para personalização.", null),
        new OptimizerOption(36, "Otimização rápida #36", "Template de otimização #36: ajuste manual disponível para personalização.", null),
        new OptimizerOption(37, "Otimização rápida #37", "Template de otimização #37: ajuste manual disponível para personalização.", null),
        new OptimizerOption(38, "Otimização rápida #38", "Template de otimização #38: ajuste manual disponível para personalização.", null),
        new OptimizerOption(39, "Otimização rápida #39", "Template de otimização #39: ajuste manual disponível para personalização.", null),
        new OptimizerOption(40, "Otimização rápida #40", "Template de otimização #40: ajuste manual disponível para personalização.", null),
        new OptimizerOption(41, "Otimização rápida #41", "Template de otimização #41: ajuste manual disponível para personalização.", null),
        new OptimizerOption(42, "Otimização rápida #42", "Template de otimização #42: ajuste manual disponível para personalização.", null),
        new OptimizerOption(43, "Otimização rápida #43", "Template de otimização #43: ajuste manual disponível para personalização.", null),
        new OptimizerOption(44, "Otimização rápida #44", "Template de otimização #44: ajuste manual disponível para personalização.", null),
        new OptimizerOption(45, "Otimização rápida #45", "Template de otimização #45: ajuste manual disponível para personalização.", null),
        new OptimizerOption(46, "Otimização rápida #46", "Template de otimização #46: ajuste manual disponível para personalização.", null),
        new OptimizerOption(47, "Otimização rápida #47", "Template de otimização #47: ajuste manual disponível para personalização.", null),
        new OptimizerOption(48, "Otimização rápida #48", "Template de otimização #48: ajuste manual disponível para personalização.", null),
        new OptimizerOption(49, "Otimização rápida #49", "Template de otimização #49: ajuste manual disponível para personalização.", null),
        new OptimizerOption(50, "Otimização rápida #50", "Template de otimização #50: ajuste manual disponível para personalização.", null),
        new OptimizerOption(51, "Otimização rápida #51", "Template de otimização #51: ajuste manual disponível para personalização.", null),
        new OptimizerOption(52, "Otimização rápida #52", "Template de otimização #52: ajuste manual disponível para personalização.", null),
        new OptimizerOption(53, "Otimização rápida #53", "Template de otimização #53: ajuste manual disponível para personalização.", null),
        new OptimizerOption(54, "Otimização rápida #54", "Template de otimização #54: ajuste manual disponível para personalização.", null),
        new OptimizerOption(55, "Otimização rápida #55", "Template de otimização #55: ajuste manual disponível para personalização.", null),
        new OptimizerOption(56, "Otimização rápida #56", "Template de otimização #56: ajuste manual disponível para personalização.", null),
        new OptimizerOption(57, "Otimização rápida #57", "Template de otimização #57: ajuste manual disponível para personalização.", null),
        new OptimizerOption(58, "Otimização rápida #58", "Template de otimização #58: ajuste manual disponível para personalização.", null),
        new OptimizerOption(59, "Otimização rápida #59", "Template de otimização #59: ajuste manual disponível para personalização.", null),
        new OptimizerOption(60, "Otimização rápida #60", "Template de otimização #60: ajuste manual disponível para personalização.", null),
        new OptimizerOption(61, "Otimização rápida #61", "Template de otimização #61: ajuste manual disponível para personalização.", null),
        new OptimizerOption(62, "Otimização rápida #62", "Template de otimização #62: ajuste manual disponível para personalização.", null),
        new OptimizerOption(63, "Otimização rápida #63", "Template de otimização #63: ajuste manual disponível para personalização.", null),
        new OptimizerOption(64, "Otimização rápida #64", "Template de otimização #64: ajuste manual disponível para personalização.", null),
        new OptimizerOption(65, "Otimização rápida #65", "Template de otimização #65: ajuste manual disponível para personalização.", null),
        new OptimizerOption(66, "Otimização rápida #66", "Template de otimização #66: ajuste manual disponível para personalização.", null),
        new OptimizerOption(67, "Otimização rápida #67", "Template de otimização #67: ajuste manual disponível para personalização.", null),
        new OptimizerOption(68, "Otimização rápida #68", "Template de otimização #68: ajuste manual disponível para personalização.", null),
        new OptimizerOption(69, "Otimização rápida #69", "Template de otimização #69: ajuste manual disponível para personalização.", null),
        new OptimizerOption(70, "Otimização rápida #70", "Template de otimização #70: ajuste manual disponível para personalização.", null),
        new OptimizerOption(71, "Otimização rápida #71", "Template de otimização #71: ajuste manual disponível para personalização.", null),
        new OptimizerOption(72, "Otimização rápida #72", "Template de otimização #72: ajuste manual disponível para personalização.", null),
        new OptimizerOption(73, "Otimização rápida #73", "Template de otimização #73: ajuste manual disponível para personalização.", null),
        new OptimizerOption(74, "Otimização rápida #74", "Template de otimização #74: ajuste manual disponível para personalização.", null),
        new OptimizerOption(75, "Otimização rápida #75", "Template de otimização #75: ajuste manual disponível para personalização.", null),
        new OptimizerOption(76, "Otimização rápida #76", "Template de otimização #76: ajuste manual disponível para personalização.", null),
        new OptimizerOption(77, "Otimização rápida #77", "Template de otimização #77: ajuste manual disponível para personalização.", null),
        new OptimizerOption(78, "Otimização rápida #78", "Template de otimização #78: ajuste manual disponível para personalização.", null),
        new OptimizerOption(79, "Otimização rápida #79", "Template de otimização #79: ajuste manual disponível para personalização.", null),
        new OptimizerOption(80, "Otimização rápida #80", "Template de otimização #80: ajuste manual disponível para personalização.", null),
        new OptimizerOption(81, "Otimização rápida #81", "Template de otimização #81: ajuste manual disponível para personalização.", null),
        new OptimizerOption(82, "Otimização rápida #82", "Template de otimização #82: ajuste manual disponível para personalização.", null),
        new OptimizerOption(83, "Otimização rápida #83", "Template de otimização #83: ajuste manual disponível para personalização.", null),
        new OptimizerOption(84, "Otimização rápida #84", "Template de otimização #84: ajuste manual disponível para personalização.", null),
        new OptimizerOption(85, "Otimização rápida #85", "Template de otimização #85: ajuste manual disponível para personalização.", null),
        new OptimizerOption(86, "Otimização rápida #86", "Template de otimização #86: ajuste manual disponível para personalização.", null),
        new OptimizerOption(87, "Otimização rápida #87", "Template de otimização #87: ajuste manual disponível para personalização.", null),
        new OptimizerOption(88, "Otimização rápida #88", "Template de otimização #88: ajuste manual disponível para personalização.", null),
        new OptimizerOption(89, "Otimização rápida #89", "Template de otimização #89: ajuste manual disponível para personalização.", null),
        new OptimizerOption(90, "Otimização rápida #90", "Template de otimização #90: ajuste manual disponível para personalização.", null),
        new OptimizerOption(91, "Otimização rápida #91", "Template de otimização #91: ajuste manual disponível para personalização.", null),
        new OptimizerOption(92, "Otimização rápida #92", "Template de otimização #92: ajuste manual disponível para personalização.", null),
        new OptimizerOption(93, "Otimização rápida #93", "Template de otimização #93: ajuste manual disponível para personalização.", null),
        new OptimizerOption(94, "Otimização rápida #94", "Template de otimização #94: ajuste manual disponível para personalização.", null),
        new OptimizerOption(95, "Otimização rápida #95", "Template de otimização #95: ajuste manual disponível para personalização.", null),
        new OptimizerOption(96, "Otimização rápida #96", "Template de otimização #96: ajuste manual disponível para personalização.", null),
        new OptimizerOption(97, "Otimização rápida #97", "Template de otimização #97: ajuste manual disponível para personalização.", null),
        new OptimizerOption(98, "Otimização rápida #98", "Template de otimização #98: ajuste manual disponível para personalização.", null),
        new OptimizerOption(99, "Otimização rápida #99", "Template de otimização #99: ajuste manual disponível para personalização.", null),
        new OptimizerOption(100, "Otimização rápida #100", "Template de otimização #100: ajuste manual disponível para personalização.", null),
        new OptimizerOption(101, "Otimização rápida #101", "Template de otimização #101: ajuste manual disponível para personalização.", null),
        new OptimizerOption(102, "Otimização rápida #102", "Template de otimização #102: ajuste manual disponível para personalização.", null),
        new OptimizerOption(103, "Otimização rápida #103", "Template de otimização #103: ajuste manual disponível para personalização.", null),
        new OptimizerOption(104, "Otimização rápida #104", "Template de otimização #104: ajuste manual disponível para personalização.", null),
        new OptimizerOption(105, "Otimização rápida #105", "Template de otimização #105: ajuste manual disponível para personalização.", null),
        new OptimizerOption(106, "Otimização rápida #106", "Template de otimização #106: ajuste manual disponível para personalização.", null),
        new OptimizerOption(107, "Otimização rápida #107", "Template de otimização #107: ajuste manual disponível para personalização.", null),
        new OptimizerOption(108, "Otimização rápida #108", "Template de otimização #108: ajuste manual disponível para personalização.", null),
        new OptimizerOption(109, "Otimização rápida #109", "Template de otimização #109: ajuste manual disponível para personalização.", null),
        new OptimizerOption(110, "Otimização rápida #110", "Template de otimização #110: ajuste manual disponível para personalização.", null),
        new OptimizerOption(111, "Otimização rápida #111", "Template de otimização #111: ajuste manual disponível para personalização.", null),
        new OptimizerOption(112, "Otimização rápida #112", "Template de otimização #112: ajuste manual disponível para personalização.", null),
        new OptimizerOption(113, "Otimização rápida #113", "Template de otimização #113: ajuste manual disponível para personalização.", null),
        new OptimizerOption(114, "Otimização rápida #114", "Template de otimização #114: ajuste manual disponível para personalização.", null),
        new OptimizerOption(115, "Otimização rápida #115", "Template de otimização #115: ajuste manual disponível para personalização.", null),
        new OptimizerOption(116, "Otimização rápida #116", "Template de otimização #116: ajuste manual disponível para personalização.", null),
        new OptimizerOption(117, "Otimização rápida #117", "Template de otimização #117: ajuste manual disponível para personalização.", null),
        new OptimizerOption(118, "Otimização rápida #118", "Template de otimização #118: ajuste manual disponível para personalização.", null),
        new OptimizerOption(119, "Otimização rápida #119", "Template de otimização #119: ajuste manual disponível para personalização.", null),
        new OptimizerOption(120, "Otimização rápida #120", "Template de otimização #120: ajuste manual disponível para personalização.", null),
        new OptimizerOption(121, "Otimização rápida #121", "Template de otimização #121: ajuste manual disponível para personalização.", null),
        new OptimizerOption(122, "Otimização rápida #122", "Template de otimização #122: ajuste manual disponível para personalização.", null),
        new OptimizerOption(123, "Otimização rápida #123", "Template de otimização #123: ajuste manual disponível para personalização.", null),
        new OptimizerOption(124, "Otimização rápida #124", "Template de otimização #124: ajuste manual disponível para personalização.", null),
        new OptimizerOption(125, "Otimização rápida #125", "Template de otimização #125: ajuste manual disponível para personalização.", null),
        new OptimizerOption(126, "Otimização rápida #126", "Template de otimização #126: ajuste manual disponível para personalização.", null),
        new OptimizerOption(127, "Otimização rápida #127", "Template de otimização #127: ajuste manual disponível para personalização.", null),
        new OptimizerOption(128, "Otimização rápida #128", "Template de otimização #128: ajuste manual disponível para personalização.", null),
        new OptimizerOption(129, "Otimização rápida #129", "Template de otimização #129: ajuste manual disponível para personalização.", null),
        new OptimizerOption(130, "Otimização rápida #130", "Template de otimização #130: ajuste manual disponível para personalização.", null),
        new OptimizerOption(131, "Otimização rápida #131", "Template de otimização #131: ajuste manual disponível para personalização.", null),
        new OptimizerOption(132, "Otimização rápida #132", "Template de otimização #132: ajuste manual disponível para personalização.", null),
        new OptimizerOption(133, "Otimização rápida #133", "Template de otimização #133: ajuste manual disponível para personalização.", null),
        new OptimizerOption(134, "Otimização rápida #134", "Template de otimização #134: ajuste manual disponível para personalização.", null),
        new OptimizerOption(135, "Otimização rápida #135", "Template de otimização #135: ajuste manual disponível para personalização.", null),
        new OptimizerOption(136, "Otimização rápida #136", "Template de otimização #136: ajuste manual disponível para personalização.", null),
        new OptimizerOption(137, "Otimização rápida #137", "Template de otimização #137: ajuste manual disponível para personalização.", null),
        new OptimizerOption(138, "Otimização rápida #138", "Template de otimização #138: ajuste manual disponível para personalização.", null),
        new OptimizerOption(139, "Otimização rápida #139", "Template de otimização #139: ajuste manual disponível para personalização.", null),
        new OptimizerOption(140, "Otimização rápida #140", "Template de otimização #140: ajuste manual disponível para personalização.", null),
        new OptimizerOption(141, "Otimização rápida #141", "Template de otimização #141: ajuste manual disponível para personalização.", null),
        new OptimizerOption(142, "Otimização rápida #142", "Template de otimização #142: ajuste manual disponível para personalização.", null),
        new OptimizerOption(143, "Otimização rápida #143", "Template de otimização #143: ajuste manual disponível para personalização.", null),
        new OptimizerOption(144, "Otimização rápida #144", "Template de otimização #144: ajuste manual disponível para personalização.", null),
        new OptimizerOption(145, "Otimização rápida #145", "Template de otimização #145: ajuste manual disponível para personalização.", null),
        new OptimizerOption(146, "Otimização rápida #146", "Template de otimização #146: ajuste manual disponível para personalização.", null),
        new OptimizerOption(147, "Otimização rápida #147", "Template de otimização #147: ajuste manual disponível para personalização.", null),
        new OptimizerOption(148, "Otimização rápida #148", "Template de otimização #148: ajuste manual disponível para personalização.", null),
        new OptimizerOption(149, "Otimização rápida #149", "Template de otimização #149: ajuste manual disponível para personalização.", null),
        new OptimizerOption(150, "Otimização rápida #150", "Template de otimização #150: ajuste manual disponível para personalização.", null),
        new OptimizerOption(151, "Otimização rápida #151", "Template de otimização #151: ajuste manual disponível para personalização.", null),
        new OptimizerOption(152, "Otimização rápida #152", "Template de otimização #152: ajuste manual disponível para personalização.", null),
        new OptimizerOption(153, "Otimização rápida #153", "Template de otimização #153: ajuste manual disponível para personalização.", null),
        new OptimizerOption(154, "Otimização rápida #154", "Template de otimização #154: ajuste manual disponível para personalização.", null),
        new OptimizerOption(155, "Otimização rápida #155", "Template de otimização #155: ajuste manual disponível para personalização.", null),
        new OptimizerOption(156, "Otimização rápida #156", "Template de otimização #156: ajuste manual disponível para personalização.", null),
        new OptimizerOption(157, "Otimização rápida #157", "Template de otimização #157: ajuste manual disponível para personalização.", null),
        new OptimizerOption(158, "Otimização rápida #158", "Template de otimização #158: ajuste manual disponível para personalização.", null),
        new OptimizerOption(159, "Otimização rápida #159", "Template de otimização #159: ajuste manual disponível para personalização.", null),
        new OptimizerOption(160, "Otimização rápida #160", "Template de otimização #160: ajuste manual disponível para personalização.", null),
        new OptimizerOption(161, "Otimização rápida #161", "Template de otimização #161: ajuste manual disponível para personalização.", null),
        new OptimizerOption(162, "Otimização rápida #162", "Template de otimização #162: ajuste manual disponível para personalização.", null),
        new OptimizerOption(163, "Otimização rápida #163", "Template de otimização #163: ajuste manual disponível para personalização.", null),
        new OptimizerOption(164, "Otimização rápida #164", "Template de otimização #164: ajuste manual disponível para personalização.", null),
        new OptimizerOption(165, "Otimização rápida #165", "Template de otimização #165: ajuste manual disponível para personalização.", null),
        new OptimizerOption(166, "Otimização rápida #166", "Template de otimização #166: ajuste manual disponível para personalização.", null),
        new OptimizerOption(167, "Otimização rápida #167", "Template de otimização #167: ajuste manual disponível para personalização.", null),
        new OptimizerOption(168, "Otimização rápida #168", "Template de otimização #168: ajuste manual disponível para personalização.", null),
        new OptimizerOption(169, "Otimização rápida #169", "Template de otimização #169: ajuste manual disponível para personalização.", null),
        new OptimizerOption(170, "Otimização rápida #170", "Template de otimização #170: ajuste manual disponível para personalização.", null),
        new OptimizerOption(171, "Otimização rápida #171", "Template de otimização #171: ajuste manual disponível para personalização.", null),
        new OptimizerOption(172, "Otimização rápida #172", "Template de otimização #172: ajuste manual disponível para personalização.", null),
        new OptimizerOption(173, "Otimização rápida #173", "Template de otimização #173: ajuste manual disponível para personalização.", null),
        new OptimizerOption(174, "Otimização rápida #174", "Template de otimização #174: ajuste manual disponível para personalização.", null),
        new OptimizerOption(175, "Otimização rápida #175", "Template de otimização #175: ajuste manual disponível para personalização.", null),
        new OptimizerOption(176, "Otimização rápida #176", "Template de otimização #176: ajuste manual disponível para personalização.", null),
        new OptimizerOption(177, "Otimização rápida #177", "Template de otimização #177: ajuste manual disponível para personalização.", null),
        new OptimizerOption(178, "Otimização rápida #178", "Template de otimização #178: ajuste manual disponível para personalização.", null),
        new OptimizerOption(179, "Otimização rápida #179", "Template de otimização #179: ajuste manual disponível para personalização.", null),
        new OptimizerOption(180, "Otimização rápida #180", "Template de otimização #180: ajuste manual disponível para personalização.", null),
        new OptimizerOption(181, "Otimização rápida #181", "Template de otimização #181: ajuste manual disponível para personalização.", null),
        new OptimizerOption(182, "Otimização rápida #182", "Template de otimização #182: ajuste manual disponível para personalização.", null),
        new OptimizerOption(183, "Otimização rápida #183", "Template de otimização #183: ajuste manual disponível para personalização.", null),
        new OptimizerOption(184, "Otimização rápida #184", "Template de otimização #184: ajuste manual disponível para personalização.", null),
        new OptimizerOption(185, "Otimização rápida #185", "Template de otimização #185: ajuste manual disponível para personalização.", null),
        new OptimizerOption(186, "Otimização rápida #186", "Template de otimização #186: ajuste manual disponível para personalização.", null),
        new OptimizerOption(187, "Otimização rápida #187", "Template de otimização #187: ajuste manual disponível para personalização.", null),
        new OptimizerOption(188, "Otimização rápida #188", "Template de otimização #188: ajuste manual disponível para personalização.", null),
        new OptimizerOption(189, "Otimização rápida #189", "Template de otimização #189: ajuste manual disponível para personalização.", null),
        new OptimizerOption(190, "Otimização rápida #190", "Template de otimização #190: ajuste manual disponível para personalização.", null),
        new OptimizerOption(191, "Otimização rápida #191", "Template de otimização #191: ajuste manual disponível para personalização.", null),
        new OptimizerOption(192, "Otimização rápida #192", "Template de otimização #192: ajuste manual disponível para personalização.", null),
        new OptimizerOption(193, "Otimização rápida #193", "Template de otimização #193: ajuste manual disponível para personalização.", null),
        new OptimizerOption(194, "Otimização rápida #194", "Template de otimização #194: ajuste manual disponível para personalização.", null),
        new OptimizerOption(195, "Otimização rápida #195", "Template de otimização #195: ajuste manual disponível para personalização.", null),
        new OptimizerOption(196, "Otimização rápida #196", "Template de otimização #196: ajuste manual disponível para personalização.", null),
        new OptimizerOption(197, "Otimização rápida #197", "Template de otimização #197: ajuste manual disponível para personalização.", null),
        new OptimizerOption(198, "Otimização rápida #198", "Template de otimização #198: ajuste manual disponível para personalização.", null),
        new OptimizerOption(199, "Otimização rápida #199", "Template de otimização #199: ajuste manual disponível para personalização.", null),
        new OptimizerOption(200, "Otimização rápida #200", "Template de otimização #200: ajuste manual disponível para personalização.", null),
        new OptimizerOption(201, "Otimização rápida #201", "Template de otimização #201: ajuste manual disponível para personalização.", null),
        new OptimizerOption(202, "Otimização rápida #202", "Template de otimização #202: ajuste manual disponível para personalização.", null),
        new OptimizerOption(203, "Otimização rápida #203", "Template de otimização #203: ajuste manual disponível para personalização.", null),
        new OptimizerOption(204, "Otimização rápida #204", "Template de otimização #204: ajuste manual disponível para personalização.", null),
        new OptimizerOption(205, "Otimização rápida #205", "Template de otimização #205: ajuste manual disponível para personalização.", null),
        new OptimizerOption(206, "Otimização rápida #206", "Template de otimização #206: ajuste manual disponível para personalização.", null),
        new OptimizerOption(207, "Otimização rápida #207", "Template de otimização #207: ajuste manual disponível para personalização.", null),
        new OptimizerOption(208, "Otimização rápida #208", "Template de otimização #208: ajuste manual disponível para personalização.", null),
        new OptimizerOption(209, "Otimização rápida #209", "Template de otimização #209: ajuste manual disponível para personalização.", null),
        new OptimizerOption(210, "Otimização rápida #210", "Template de otimização #210: ajuste manual disponível para personalização.", null),
        new OptimizerOption(211, "Otimização rápida #211", "Template de otimização #211: ajuste manual disponível para personalização.", null),
        new OptimizerOption(212, "Otimização rápida #212", "Template de otimização #212: ajuste manual disponível para personalização.", null),
        new OptimizerOption(213, "Otimização rápida #213", "Template de otimização #213: ajuste manual disponível para personalização.", null),
        new OptimizerOption(214, "Otimização rápida #214", "Template de otimização #214: ajuste manual disponível para personalização.", null),
        new OptimizerOption(215, "Otimização rápida #215", "Template de otimização #215: ajuste manual disponível para personalização.", null),
        new OptimizerOption(216, "Otimização rápida #216", "Template de otimização #216: ajuste manual disponível para personalização.", null),
        new OptimizerOption(217, "Otimização rápida #217", "Template de otimização #217: ajuste manual disponível para personalização.", null),
        new OptimizerOption(218, "Otimização rápida #218", "Template de otimização #218: ajuste manual disponível para personalização.", null),
        new OptimizerOption(219, "Otimização rápida #219", "Template de otimização #219: ajuste manual disponível para personalização.", null),
        new OptimizerOption(220, "Otimização rápida #220", "Template de otimização #220: ajuste manual disponível para personalização.", null),
        new OptimizerOption(221, "Otimização rápida #221", "Template de otimização #221: ajuste manual disponível para personalização.", null),
        new OptimizerOption(222, "Otimização rápida #222", "Template de otimização #222: ajuste manual disponível para personalização.", null),
        new OptimizerOption(223, "Otimização rápida #223", "Template de otimização #223: ajuste manual disponível para personalização.", null),
        new OptimizerOption(224, "Otimização rápida #224", "Template de otimização #224: ajuste manual disponível para personalização.", null),
        new OptimizerOption(225, "Otimização rápida #225", "Template de otimização #225: ajuste manual disponível para personalização.", null),
        new OptimizerOption(226, "Otimização rápida #226", "Template de otimização #226: ajuste manual disponível para personalização.", null),
        new OptimizerOption(227, "Otimização rápida #227", "Template de otimização #227: ajuste manual disponível para personalização.", null),
        new OptimizerOption(228, "Otimização rápida #228", "Template de otimização #228: ajuste manual disponível para personalização.", null),
        new OptimizerOption(229, "Otimização rápida #229", "Template de otimização #229: ajuste manual disponível para personalização.", null),
        new OptimizerOption(230, "Otimização rápida #230", "Template de otimização #230: ajuste manual disponível para personalização.", null),
        new OptimizerOption(231, "Otimização rápida #231", "Template de otimização #231: ajuste manual disponível para personalização.", null),
        new OptimizerOption(232, "Otimização rápida #232", "Template de otimização #232: ajuste manual disponível para personalização.", null),
        new OptimizerOption(233, "Otimização rápida #233", "Template de otimização #233: ajuste manual disponível para personalização.", null),
        new OptimizerOption(234, "Otimização rápida #234", "Template de otimização #234: ajuste manual disponível para personalização.", null),
        new OptimizerOption(235, "Otimização rápida #235", "Template de otimização #235: ajuste manual disponível para personalização.", null),
        new OptimizerOption(236, "Otimização rápida #236", "Template de otimização #236: ajuste manual disponível para personalização.", null),
        new OptimizerOption(237, "Otimização rápida #237", "Template de otimização #237: ajuste manual disponível para personalização.", null),
        new OptimizerOption(238, "Otimização rápida #238", "Template de otimização #238: ajuste manual disponível para personalização.", null),
        new OptimizerOption(239, "Otimização rápida #239", "Template de otimização #239: ajuste manual disponível para personalização.", null),
        new OptimizerOption(240, "Otimização rápida #240", "Template de otimização #240: ajuste manual disponível para personalização.", null),
        new OptimizerOption(241, "Otimização rápida #241", "Template de otimização #241: ajuste manual disponível para personalização.", null),
        new OptimizerOption(242, "Otimização rápida #242", "Template de otimização #242: ajuste manual disponível para personalização.", null),
        new OptimizerOption(243, "Otimização rápida #243", "Template de otimização #243: ajuste manual disponível para personalização.", null),
        new OptimizerOption(244, "Otimização rápida #244", "Template de otimização #244: ajuste manual disponível para personalização.", null),
        new OptimizerOption(245, "Otimização rápida #245", "Template de otimização #245: ajuste manual disponível para personalização.", null),
        new OptimizerOption(246, "Otimização rápida #246", "Template de otimização #246: ajuste manual disponível para personalização.", null),
        new OptimizerOption(247, "Otimização rápida #247", "Template de otimização #247: ajuste manual disponível para personalização.", null),
        new OptimizerOption(248, "Otimização rápida #248", "Template de otimização #248: ajuste manual disponível para personalização.", null),
        new OptimizerOption(249, "Otimização rápida #249", "Template de otimização #249: ajuste manual disponível para personalização.", null),
        new OptimizerOption(250, "Otimização rápida #250", "Template de otimização #250: ajuste manual disponível para personalização.", null),
        new OptimizerOption(251, "Otimização rápida #251", "Template de otimização #251: ajuste manual disponível para personalização.", null),
        new OptimizerOption(252, "Otimização rápida #252", "Template de otimização #252: ajuste manual disponível para personalização.", null),
        new OptimizerOption(253, "Otimização rápida #253", "Template de otimização #253: ajuste manual disponível para personalização.", null),
        new OptimizerOption(254, "Otimização rápida #254", "Template de otimização #254: ajuste manual disponível para personalização.", null),
        new OptimizerOption(255, "Otimização rápida #255", "Template de otimização #255: ajuste manual disponível para personalização.", null),
        new OptimizerOption(256, "Otimização rápida #256", "Template de otimização #256: ajuste manual disponível para personalização.", null),
        new OptimizerOption(257, "Otimização rápida #257", "Template de otimização #257: ajuste manual disponível para personalização.", null),
        new OptimizerOption(258, "Otimização rápida #258", "Template de otimização #258: ajuste manual disponível para personalização.", null),
        new OptimizerOption(259, "Otimização rápida #259", "Template de otimização #259: ajuste manual disponível para personalização.", null),
        new OptimizerOption(260, "Otimização rápida #260", "Template de otimização #260: ajuste manual disponível para personalização.", null),
        new OptimizerOption(261, "Otimização rápida #261", "Template de otimização #261: ajuste manual disponível para personalização.", null),
        new OptimizerOption(262, "Otimização rápida #262", "Template de otimização #262: ajuste manual disponível para personalização.", null),
        new OptimizerOption(263, "Otimização rápida #263", "Template de otimização #263: ajuste manual disponível para personalização.", null),
        new OptimizerOption(264, "Otimização rápida #264", "Template de otimização #264: ajuste manual disponível para personalização.", null),
        new OptimizerOption(265, "Otimização rápida #265", "Template de otimização #265: ajuste manual disponível para personalização.", null),
        new OptimizerOption(266, "Otimização rápida #266", "Template de otimização #266: ajuste manual disponível para personalização.", null),
        new OptimizerOption(267, "Otimização rápida #267", "Template de otimização #267: ajuste manual disponível para personalização.", null),
        new OptimizerOption(268, "Otimização rápida #268", "Template de otimização #268: ajuste manual disponível para personalização.", null),
        new OptimizerOption(269, "Otimização rápida #269", "Template de otimização #269: ajuste manual disponível para personalização.", null),
        new OptimizerOption(270, "Otimização rápida #270", "Template de otimização #270: ajuste manual disponível para personalização.", null),
        new OptimizerOption(271, "Otimização rápida #271", "Template de otimização #271: ajuste manual disponível para personalização.", null),
        new OptimizerOption(272, "Otimização rápida #272", "Template de otimização #272: ajuste manual disponível para personalização.", null),
        new OptimizerOption(273, "Otimização rápida #273", "Template de otimização #273: ajuste manual disponível para personalização.", null),
        new OptimizerOption(274, "Otimização rápida #274", "Template de otimização #274: ajuste manual disponível para personalização.", null),
        new OptimizerOption(275, "Otimização rápida #275", "Template de otimização #275: ajuste manual disponível para personalização.", null),
        new OptimizerOption(276, "Otimização rápida #276", "Template de otimização #276: ajuste manual disponível para personalização.", null),
        new OptimizerOption(277, "Otimização rápida #277", "Template de otimização #277: ajuste manual disponível para personalização.", null),
        new OptimizerOption(278, "Otimização rápida #278", "Template de otimização #278: ajuste manual disponível para personalização.", null),
        new OptimizerOption(279, "Otimização rápida #279", "Template de otimização #279: ajuste manual disponível para personalização.", null),
        new OptimizerOption(280, "Otimização rápida #280", "Template de otimização #280: ajuste manual disponível para personalização.", null),
        new OptimizerOption(281, "Otimização rápida #281", "Template de otimização #281: ajuste manual disponível para personalização.", null),
        new OptimizerOption(282, "Otimização rápida #282", "Template de otimização #282: ajuste manual disponível para personalização.", null),
        new OptimizerOption(283, "Otimização rápida #283", "Template de otimização #283: ajuste manual disponível para personalização.", null),
        new OptimizerOption(284, "Otimização rápida #284", "Template de otimização #284: ajuste manual disponível para personalização.", null),
        new OptimizerOption(285, "Otimização rápida #285", "Template de otimização #285: ajuste manual disponível para personalização.", null),
        new OptimizerOption(286, "Otimização rápida #286", "Template de otimização #286: ajuste manual disponível para personalização.", null),
        new OptimizerOption(287, "Otimização rápida #287", "Template de otimização #287: ajuste manual disponível para personalização.", null),
        new OptimizerOption(288, "Otimização rápida #288", "Template de otimização #288: ajuste manual disponível para personalização.", null),
        new OptimizerOption(289, "Otimização rápida #289", "Template de otimização #289: ajuste manual disponível para personalização.", null),
        new OptimizerOption(290, "Otimização rápida #290", "Template de otimização #290: ajuste manual disponível para personalização.", null),
        new OptimizerOption(291, "Otimização rápida #291", "Template de otimização #291: ajuste manual disponível para personalização.", null),
        new OptimizerOption(292, "Otimização rápida #292", "Template de otimização #292: ajuste manual disponível para personalização.", null),
        new OptimizerOption(293, "Otimização rápida #293", "Template de otimização #293: ajuste manual disponível para personalização.", null),
        new OptimizerOption(294, "Otimização rápida #294", "Template de otimização #294: ajuste manual disponível para personalização.", null),
        new OptimizerOption(295, "Otimização rápida #295", "Template de otimização #295: ajuste manual disponível para personalização.", null),
        new OptimizerOption(296, "Otimização rápida #296", "Template de otimização #296: ajuste manual disponível para personalização.", null),
        new OptimizerOption(297, "Otimização rápida #297", "Template de otimização #297: ajuste manual disponível para personalização.", null),
        new OptimizerOption(298, "Otimização rápida #298", "Template de otimização #298: ajuste manual disponível para personalização.", null),
        new OptimizerOption(299, "Otimização rápida #299", "Template de otimização #299: ajuste manual disponível para personalização.", null),
        new OptimizerOption(300, "Otimização rápida #300", "Template de otimização #300: ajuste manual disponível para personalização.", null),
    };

    return options;
}

static void RunCommand(string command)
{
    try
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {command}",
            UseShellExecute = false
        };

        using var process = Process.Start(startInfo);
        process?.WaitForExit();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao executar comando: {ex.Message}");
    }
}

internal sealed record OptimizerOption(int Id, string Title, string Description, string? Command);