<template>
    
      <section class="ma-5 mt-10">
        <v-hover>
                <template v-slot="{ hover }">
                <v-card
                        class="mx-auto p-3"
                        max-width="600"
                            
                        :elevation="hover ? 24 : 1"    
                >
                <div v-for="(post,index) in posts" :key="index">
                    <div v-if="proId == post.botsid">
                    <v-img
                            class="white--text align-end"
                            height="250px"
                            :src="post.image"
                    >
                    <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                    </v-img>

                    <v-card-subtitle class="pb-0">Blizzard Entertainment</v-card-subtitle>

                    <v-card-text class=" pb-0">
                        <div><h2 class="text--primary my-1">Senior Software Engineer, Gameplay</h2></div>
                        <div class="pb-0">California &#183; C++, 5 years experience  &#183; Professional</div>
                        <h3 class="text--primary my-3" >About our company</h3>
                            <p class="text--primary">
                                Blizzard Entertainment is seeking a talented and passionate Sr. Software Engineer, Gameplay to design and architect 
                                compelling gameplay systems for an unannounced project. As a Sr. Software Engineer focused on gameplay, you will champion
                                Blizzard’s core value of “Gameplay First” as you collaborate with a small team of designers, engineers, and artists responsible 
                                for defining the core elements of this exciting new project. 
                                The ideal candidate will have experience working on gameplay aspects of core combat in modern 1st/3rd person AAA titles. By blending your mastery of 
                                programming with a critical eye for design, you will help architect and implement an epic gameplay experience. 
                                Our incubation teams are fast paced and mission critical. We love engineering, geeking out over new technology, and helping move the industry forward.
                                 Most importantly,
                                we learn, grow, and ultimately enjoy success as a team, overcoming new challenges together.
                            </p>
                            <h3 class="text--primary">Мы предлагаем дорогому соискателю, пройти небольшой опрос,
                               на основании которого мы будем рассматривать вашу Кандидатуру
                            </h3>
                            <p>**пошли вопросы**</p>
                    </v-card-text>

                    <v-card>
                      
                       <v-list-item>
                          
                        <v-list-item-content>
                            <v-list-item-title><p>привет</p></v-list-item-title>
                            <v-btn-toggle
                                    v-model="toggle_exclusive"
                                    class="mx-auto"
                            >
                               
                            </v-btn-toggle>
                        </v-list-item-content>
                    </v-list-item>
                     
                        
                    </v-card>
                    <v-btn class="ma-3" 
                                color="cyan lighten-1"
                                text
                        >
                            send
                        </v-btn>
                           </div>
                        </div>
                </v-card>
                </template>
            </v-hover>
        </section>  
</template>

<script>
    import axios from 'axios';
    export default {
        data() {
            return {
                proId:this.$route.params.Pid,
                direction: 'bottom',
                fab: false,
                globalid: null,
                dialog: false,
                redactPost: false,
                message: null,
                show: true,
                n: 0,
                items: [],
                posts: [],
                errors: [],
                redlabel: "",
                formIsValid: [
                    (v) => !!v || 'Field is required'
                ]
            }
        },
        created() {
      axios.get(`https://my-json-server.typicode.com/AlexanderPanshin/dpv.school/user`)
      .then(response=> {
        this.items= response.data;
      })
      .catch(error=> {
        window.console.log(error);
        this.errored=true;
                })
      axios.get(`https://my-json-server.typicode.com/AlexanderPanshin/dpv.school/bots`)
      .then(response=> {
        this.posts= response.data;
      })
      .catch(error=> {
        window.console.log(error);
        this.errored=true;
                })
        },
        
            }
        
    
</script>


 