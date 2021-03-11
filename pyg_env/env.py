import pygame,sys




class car:
    def __init__(self,x,y): 
        self.x = x
        self.y = y
        self.rect = pygame.rect.Rect((self.x,self.y,70,50))
        
    def move(self):
        key = pygame.key.get_pressed()
        if(key[pygame.K_RIGHT]):
            self.rect.move_ip(1, 0)
        if(key[pygame.K_LEFT]):
            self.rect.move_ip(-1, 0)
        if(key[pygame.K_UP]):
            self.rect.move_ip(0, -1)
        if(key[pygame.K_DOWN]):
            self.rect.move_ip(0, 1)
        
        

    def draw(self,screen):
        pygame.draw.rect(screen,(255,0,0),self.rect)
        


def main():
    #VARIABLES
    clock = pygame.time.Clock()

    WIDTH = 1000
    HEIGHT = 800
    #colors of the env
    BG =  (0,255,0)
    ROAD = (70,70,70)
    screen = pygame.display.set_mode((WIDTH,HEIGHT))
    pygame.display.set_caption('DRIVER SIMULATION')


    #draw a car
    Car =  car(0,HEIGHT/2)
  
    pygame.display.flip()

    while True:
        for event in pygame.event.get():
            if event.type==pygame.QUIT:
                pygame.quit()
                sys.exit()

        screen.fill(BG)

        #draw road
        pygame.draw.rect(screen,ROAD,(0,HEIGHT/3,WIDTH,HEIGHT/3))   
        #draw start and goal
        pygame.draw.rect(screen,(255,255,255),(0,HEIGHT/3,WIDTH/15,HEIGHT/3))
        pygame.draw.rect(screen,(255,255,255),(WIDTH -WIDTH/15,HEIGHT/3,WIDTH,HEIGHT/3))
        Car.draw(screen)
        Car.move()
        pygame.display.update()
        clock.tick(300)

main()
