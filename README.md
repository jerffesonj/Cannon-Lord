# Cannon-Lord
Como executar: o jogo se encontra nos links abaixo: 
    Versão WebGL - https://jerffesonj.itch.io/canon-lord 
    Versão Windows - https://drive.google.com/file/d/1oSBvWGiEqal9lO6q1jfqu9TYyz07GkcG/view?usp=sharing
Para jogar: R - recarrega
            Mouse - rotaciona o personagem
            Clique esquerdo: atira

	O projeto foi organizado por tipo de arquivo. A escolha dessa organização foi feita por ser um projeto simples que utilizaria poucos arquivos e também por ser mais fácil de localizar caso fosse necessário.
	Na pasta Animations foram colocados os arquivos referentes a animações, como as animações de tiro, morte do inimigo e efeitos de sangue.
	Na pasta Audios foram inseridos os arquivos de audio utilizados no projeto. Como por exemplo o som de tiro, som de dano do inimigo e som de morte do mesmo.
	Na pasta prefabs foram organizados todos os prefabs utilizados no jogo. Como a bala que o personagem atira, os diferentes tipos de inimigos e também outros tipos de objetos que podem ser reutilizados em outras cenas, como o Canvas, o Cenário, o Spawn de inimigos e objetos utilizados para melhorar a parte de efeitos do jogo.
	A pasta Resources foi criada apenas para criar um material da cor branca para criar o efeito de flash nos inimigos e personagem quando sofrem algum tipo de dano.
	A pasta Scripts contem todos os scripts utilizados no projeto.
	A pasta TextMeshPro é uma pasta relacionada do plugin de texto utilizado no projeto.
	Na pasta Tilemap se encontram as imagens utilizadas como tilemap para a construção do cenário.
	A pasta WaveScriptable contem Scriptable Objects utilizados para criar as waves de inimigos durante o jogo. E dentro desta pasta há os caminhos (waypoints) que cada tipo de inimigo deve seguir.
	As pastas iniciadas com "Z", a Z-Backyard - Free e Z-TopDownGunPack são pastas de assets grátis utilizados no projetos. Podem ser encontrados nos links a seguir:     
    https://assetstore.unity.com/packages/2d/environments/backyard-top-down-tileset-53854
    https://assetstore.unity.com/packages/templates/packs/top-down-gun-pack-35277
   
  	Utilizando como jogo base, foi verificado que a forma de jogar era lenta, onde o jogador deveria esperar o canhão chegar no local desejado para poder atirar. Onde para atirar era necessário clicar em um botão no canto superior da tela.
  	Foi pensado para melhorar a jogabilidade em que o próprio jogador pudesse rotacionar o personagem e também atirar com o clique do mouse. E como forma de adicionar mecânicas no jogo, também foram adicionados a barra de vida do personagem, onde caso chegasse a zero, o jogador perdia o jogo, a melhoria de velocidade de tiro do personagem e a mecânica de recarregamento de arma, além de adição de vários tipos de inimigos, onde cada um tem uma forma diferente de movimento, vida e velocidades diferentes. Isso foi pensado para que o jogador tivesse mais coisas para pensar além de apenas atirar e esperar o canhão rotacionar para poder atirar novamente.
  	Para a implementação da mecânica de rotacionar o personagem e atirar, foi levado aproximadamente 1 hora, já que foi necessário utilizar o cálculo de vetor entre o local de onde o personagem está para o local fica o mouse, além de também fazer o cálculo de rotação para que o personagem rotacionasse em relação do local do mouse. Após isso foi implementada a mecânica de atirar. 
	Logo após foi criado o inimigo, onde o mesmo deveria seguir um caminho predefinido e chegar no local onde o personagem está. Para isso foi criado um script de spawn de inimigos, um script de vida (para que o inimigo pudesse morrer) e um Scriptable Object, que serviria para saber o número de inimigos que deveriam ser spawnados, a velocidade de movimento e o tempo de spawn que cada inimigo teria. Essa implementação demorou aproximadamente 3 horas. Já que se trata da parte principal do jogo, demandaria mais tempo para criar, porém essa demora valeu a pena, pois, utilizando Scriptable Objects, a wave basicamente estaria pronta, sendo apenas necessário inserir o tipo de inimigo e o caminho que ele deveria seguir para funcionar.
	Depois desse processo, foi adicionado o dano que o personagem sofria ao inimigo atravessar o local, junto com a implementação de feedback sonoro do tiro e do dano sofrido do inimigo, além do feedback visual quando o personagem e o inimigo sofriam dano. Esse processo levou aproximadamente 1 hora, pois além de implementar esse feedback, também foi necessário fazer testes para ter certeza que tudo funcionava perfeitamente.
	Também foi implementado o feedback utilizando o Canvas, com a adição de pontos ao derrotar os inimigos, a recuperação de vida ao chegar a um certo valor de pontos, a vida restante do jogador e também mostrando o número de balas atuais e máxima do jogador. Esse processo foi rápido, durou aproximadamente 30 minutos, já que era apenas necessário referenciar esse valores em textos no Canvas.
	Também foi feito a implementação de efeitos visuais no projeto. Utilizando animações de sangue a atirar no inimigo e animações de morte ao derrota-los. Esse processo durou aproximadamente 1 hora e meia, já que foi necessário criar as animações na Unity e também fazer com que elas funcionassem dentro do jogo.
	A parte mais que mais demorou durante todo o processo foi a de teste. Já que para fazer com que o jogador se divertisse enquanto jogava, foi necessário fazer alguns teste de quanto tempo o inimigo demorava a morrer, o número de inimigos por wave, a velocidade em que ele se movia, o número máximo de balas que o jogador teria. Por ser um processo mais espaçado, onde era feito basicamente após a implementação da mecânica não tem uma forma de realmente calcular. Porém baseado no tempo gasto entre uma implementação e outra pode-se a chegar a aproximadamente mais de 2 horas e meia de testes.
	
	Para o versionamento do projeto, foi utilizado o Unity Collab. Onde para cada grande mudança, seria upado o projeto com os arquivos modificados. E caso fosse necessário utilizar um arquivos de uma versão anterior era apenas restaura-lo.
