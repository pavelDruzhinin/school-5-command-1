<template>
    <div class="d-flex flex-row flex-wrap justify-center">





  
            <!--Карточка1 - Яндекс-->
        <section class="ma-5 mt-10">
        <v-hover>
                <template v-slot="{ hover }">
                <v-card
                        class=" p-3"
                        max-width="400"
                        :elevation="hover ? 24 : 1"    
                >
                    <v-img
                            class="white--text align-end"
                            height="200px"
                            src="https://avatars.mds.yandex.net/get-pdb/1626505/accb297d-7c01-405e-a97d-82c4c5abbadf/s1200?webp=false"
                    >
                    <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                    </v-img>

                    <v-card-subtitle class="pb-0">Yandex.Inc</v-card-subtitle>

                    <v-card-text class=" pb-0">
                        <div ><h3 class="text--primary">Yandex Academic Supervision Program</h3></div>
                        <div >Moscow &#183; Python, C++ &#183; Specialist</div>
                    </v-card-text>

                    <v-card-actions>
                        <v-btn
                                color="cyan lighten-1"
                                text
                        >
                            begin
                        </v-btn>
                    </v-card-actions>
                </v-card>
                </template>
            </v-hover>
        </section>  
            
            
            <!--Карточка2 -Гугл-->
        <section class="ma-5 mt-10">
        <v-hover>
                <template v-slot="{ hover }">
                <v-card
                        class="mx-auto p-3"
                        max-width="400"
                        :elevation="hover ? 24 : 1"    
                >
                    <v-img
                            class="white--text align-end"
                            height="200px"
                            src="https://zhiznonline.ru/wp-content/uploads/2019/01/1-1142.jpg"
                    >
                    <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                    </v-img>

                    <v-card-subtitle class="pb-0">Google.Inc</v-card-subtitle>

                    <v-card-text class=" pb-0">
                        <div><h3 class="text--primary">UX Engineer, Front End, iOS</h3></div>
                        <div class="pb-0">San Francisco &#183; Objective-C, Swif&#183; Specialist</div>
                    </v-card-text>

                    <v-card-actions>
                        <v-btn
                                color="cyan lighten-1"
                                text
                        >
                            begin
                        </v-btn>
                    </v-card-actions>
                </v-card>
                </template>
            </v-hover>
        </section>  
            

            <!--Карточка3 - Тесла-->
        <section class="ma-5 mt-10">
        <v-hover>
                <template v-slot="{ hover }">
                <v-card
                        class="mx-auto p-3"
                        max-width="400"
                        :elevation="hover ? 24 : 1"    
                >
                    <v-img
                            class="white--text align-end"
                            height="200px"
                            src="https://pbs.twimg.com/media/D3dNX6zWkAAG2CH.jpg:large"
                    >
                    <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                    </v-img>

                    <v-card-subtitle class="pb-0">Tesla.Inc</v-card-subtitle>

                    <v-card-text class=" pb-0">
                        <div><h3 class="text--primary">Senior Passive Safety Test Engineer</h3></div>
                        <div class="pb-0">Palo Alto &#183; Microelectronics &#183; Senior</div>
                    </v-card-text>

                    <v-card-actions>
                        <v-btn
                                color="cyan lighten-1"
                                text
                        >
                            begin
                        </v-btn>
                    </v-card-actions>
                </v-card>
                </template>
            </v-hover>
        </section>  
            

            
            <!--Карточка4 - Амазон-->
        <section class="ma-5 mt-10">
        <v-hover>
                <template v-slot="{ hover }">
                <v-card
                        class="mx-auto p-3"
                        max-width="400"
                        :elevation="hover ? 24 : 1"    
                >
                    <v-img
                            class="white--text align-end"
                            height="200px"
                            src="https://pbs.twimg.com/media/Dsk_StcWsAA7V0u.jpg:large"
                    >
                    <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                    </v-img>

                    <v-card-subtitle class="pb-0">Amazon</v-card-subtitle>

                    <v-card-text class=" pb-0">
                        <div><h3 class="text--primary">Specialized Technical Account Manager </h3></div>
                        <div class="pb-0">New York &#183; Manager, media  &#183; Specialist</div>
                    </v-card-text>

                    <v-card-actions>
                        <v-btn
                                color="cyan lighten-1"
                                text
                        >
                            begin
                        </v-btn>
                    </v-card-actions>
                </v-card>
                </template>
            </v-hover>
        </section>  
            
            <!--Карточка5 - Близзард-->
         <section class="ma-5 mt-10">
        <v-hover>
                <template v-slot="{ hover }">
                <v-card
                        class="mx-auto p-3"
                        max-width="400"
                            
                        :elevation="hover ? 24 : 1"    
                >
                    <v-img
                            class="white--text align-end"
                            height="200px"
                            src="https://finalweapon.net/wp-content/uploads/2019/07/Blizzard-KV.jpg"
                    >
                    <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                    </v-img>

                    <v-card-subtitle class="pb-0">Blizzard Entertainment</v-card-subtitle>

                    <v-card-text class=" pb-0">
                        <div><h3 class="text--primary">Senior Software Engineer, Gameplay</h3></div>
                        <div class="pb-0">California &#183; C++, 5 years experience  &#183; Professional</div>
                    </v-card-text>

                    <v-card-actions>
                        <v-btn
                                color="cyan lighten-1"
                                text
                        >
                            begin
                        </v-btn>
                    </v-card-actions>
                </v-card>
                </template>
            </v-hover>
        </section>  


            <!--Карточка6 - Близзард-->
        <section class="ma-5 mt-10">
        <v-hover>
                <template v-slot="{ hover }">
                <v-card
                        class="mx-auto p-3"
                        max-width="400"
                            
                        :elevation="hover ? 24 : 1"    
                >
                    <v-img
                            class="white--text align-end"
                            height="200px"
                            src="https://img3.goodfon.ru/original/1920x1200/b/2b/intel-logo-intel-logotip-3579.jpg"
                    >
                    <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                    </v-img>

                    <v-card-subtitle class="pb-0">Intel</v-card-subtitle>

                    <v-card-text class=" pb-0">
                        <div><h3 class="text--primary">CPU pre-silicon verification Engineer</h3></div>
                        <div class="pb-0">Santa Clara &#183;  Degree in Engineering,Software  &#183; Engineering</div>
                    </v-card-text>

                    <v-card-actions>
                        <v-btn
                                color="cyan lighten-1"
                                text
                        >
                            begin
                        </v-btn>
                    </v-card-actions>
                </v-card>
                </template>
            </v-hover>
        </section> 




          <!--Карточка7 - Dvp.soft-->
         <section class="ma-5 mt-10">
        <v-hover>
                <template v-slot="{ hover }">
                <v-card
                        class="mx-auto p-3"
                        max-width="400"
                        
                        :elevation="hover ? 24 : 1"    
                >
                    <v-img
                            class="white--text align-end"
                            height="200px"
                            src="https://sun9-3.userapi.com/c858432/v858432587/5123b/0s0W9LhXWs8.jpg"
                    >
                    <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                    </v-img>

                    <v-card-subtitle class="pb-0">Dvp.soft</v-card-subtitle>

                    <v-card-text class=" pb-0">
                        <div><h3 class="text--primary">Senior Software Engineer, Gameplay</h3></div>
                        <div class="pb-0">Petrozavodsk &#183; Html, Css, Vue.js, React  &#183; Junior</div>
                    </v-card-text>

                    <v-card-actions>
                        <v-btn
                                color="cyan lighten-1"
                                text
                        >
                            begin
                        </v-btn>
                    </v-card-actions>
                </v-card>
                </template>
            </v-hover>
        </section>  



 <!--Карточка7 - Dvp.soft-->
         <section class="ma-5 mt-10">
        <v-hover>
                <template v-slot="{ hover }">
                <v-card
                        class="mx-auto p-3"
                        max-width="400"
                        
                        :elevation="hover ? 24 : 1"    
                >
                    <v-img
                            class="white--text align-end"
                            height="200px"
                            src="https://www.belekomahaber.com/wp-content/uploads/2018/08/bilecik1.jpg"
                    >
                    <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                    </v-img>

                    <v-card-subtitle class="pb-0">Dvp.soft</v-card-subtitle>

                    <v-card-text class=" pb-0">
                        <div><h3 class="text--primary">Developer C++ (Mobile, KasperskyOS)</h3></div>
                        <div class="pb-0">Sankt-Peterburg  &#183; C/C++, Posix.API  &#183; Senior</div>
                    </v-card-text>

                    <v-card-actions>
                        <v-btn
                                color="cyan lighten-1"
                                text
                        >
                            begin
                        </v-btn>
                    </v-card-actions>
                </v-card>
                </template>
            </v-hover>
        </section>  




        <!--<v-card
                class="mx-auto mx-10"
                max-width="400"
        >
            <v-img
                    class="white--text align-end"
                    height="200px"
                    src="https://avatars.mds.yandex.net/get-pdb/1626505/accb297d-7c01-405e-a97d-82c4c5abbadf/s1200?webp=false"
            >
             <v-card-title>Top 10 Australian beaches</v-card-title>
            </v-img>

            <v-card-subtitle class="pb-0">Yandex.Inc</v-card-subtitle>

            <v-card-text >
                <div><h3 class="text--primary">Yandex Academic Supervision Program</h3></div>
                <div class="pb-0">Moscow &#183; Python, C++ &#183; Specialist</div>
            </v-card-text>

            <v-card-actions>
                <v-btn
                        color="cyan lighten-1"
                        text
                >
                    begin
                </v-btn>
            </v-card-actions>
        </v-card>-->










    </div>
    
</template>