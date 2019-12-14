<template>
    <div class="d-flex flex-row flex-wrap justify-center">



        <!--глобальная секция карточки-->
        <section class="d-flex flex-row flex-wrap justify-center">
            <div v-for="(post,index) in posts" :key="index">
                <div v-if="proId == post.botsid">
        
                    <!--Карточка1 - Яндекс-->
                <section class="ma-5 mt-10"  >
                <v-hover>
                        <template v-slot="{ hover }">
                        <v-card
                                class=" p-3"
                                max-width="400"
                                :elevation="hover ? 24 : 1" 
                                
                        >
                    <span v-bind:class="{'d-none': !post.canceled}">
                        <v-icon  color="green"  class="pos"  medium large>
                            mdi-checkbox-marked
                            </v-icon>
                    </span>  
                            <v-img
                                    class="white--text align-end"
                                    
                                    height="200px"
                                    :src="post.image"
                            >
                            
                            <!--   <v-card-title>Top 10 Australian beaches</v-card-title>-->
                            </v-img>
                            

                            <v-card-subtitle class="pb-0">{{post.company}} </v-card-subtitle>

                            <v-card-text class=" pb-0">
                                <div ><h3 class="text--primary">{{post.title}}</h3></div>
                            
                                <!--<div v-for="post in posts" :key="post"><p>{{post.id}}</p></div>-->
                                <div >{{post.geo}} &#183; {{post.skills}}&#183; {{post.position}}</div>
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
                </div>
            </div> 
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
<style >
.pos{
    position: absolute;
    z-index:1;
    margin: 6px
}
</style>


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
