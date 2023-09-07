<template>
    <div class="card">
        <div class="card-body">

            <!-- 用户信息 -->
            <div class="user-info">
                <img class="img-fluid" :src="content.avatar" style="width: 30px;"> <!-- 用户头像 -->
                {{ content.username }} <!-- 用户昵称 -->
            </div>

            <div class="colored-line"></div> <!-- 分隔线 -->

            <!-- 花园名称 -->
            <div class="garden-name">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" fill="currentColor" class="bi bi-star"
                    viewBox="0 0 16 16">
                    <path
                        d="M2.866 14.85c-.078.444.36.791.746.593l4.39-2.256 4.389 2.256c.386.198.824-.149.746-.592l-.83-4.73 3.522-3.356c.33-.314.16-.888-.282-.95l-4.898-.696L8.465.792a.513.513 0 0 0-.927 0L5.354 5.12l-4.898.696c-.441.062-.612.636-.283.95l3.523 3.356-.83 4.73zm4.905-2.767-3.686 1.894.694-3.957a.565.565 0 0 0-.163-.505L1.71 6.745l4.052-.576a.525.525 0 0 0 .393-.288L8 2.223l1.847 3.658a.525.525 0 0 0 .393.288l4.052.575-2.906 2.77a.565.565 0 0 0-.163.506l.694 3.957-3.686-1.894a.503.503 0 0 0-.461 0z" />
                </svg>
                名称： {{ content.gardenname }}
            </div>

            <!-- 花园图片 -->
            <div class="garden-img-field">
                <img :src="content.imageUrl" alt="花园图片" style="width: 60%">
            </div>

            <!-- 地点 -->
            <div class="garden-location">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" fill="currentColor" class="bi bi-geo-alt"
                    viewBox="0 0 16 16">
                    <path
                        d="M12.166 8.94c-.524 1.062-1.234 2.12-1.96 3.07A31.493 31.493 0 0 1 8 14.58a31.481 31.481 0 0 1-2.206-2.57c-.726-.95-1.436-2.008-1.96-3.07C3.304 7.867 3 6.862 3 6a5 5 0 0 1 10 0c0 .862-.305 1.867-.834 2.94zM8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10z" />
                    <path d="M8 8a2 2 0 1 1 0-4 2 2 0 0 1 0 4zm0 1a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" />
                </svg>
                地点： {{ content.location }}
            </div>

            <div class="colored-line"></div> <!-- 分隔线 -->

            <!-- 详情 -->
            <div class="discription">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" fill="currentColor" class="bi bi-justify"
                    viewBox="0 0 16 16">
                    <path fill-rule="evenodd"
                        d="M2 12.5a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5z" />
                </svg>
                描述：<br>
                <p style="font-weight: normal; font-size:2vh;">{{ content.describe }}</p>
            </div>
        </div>
    </div>
</template>

<style scoped>
.card {
    padding: 2vh;
    margin: 3vh;

    border-width: 0vh;
    border-radius: 2vh;

    box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
    background-color: rgb(244, 237, 228);

    margin-top: 3vh;
    margin-bottom: 3vh;
}

.colored-line {
    height: 1px;
    background-color: rgb(12, 60, 38);
    margin-top: 2vh;
    margin-bottom: 2vh;
}

.user-info {
    font-size: 3vh;
    font-weight: bold;
    color: rgb(12, 60, 38);

    margin-top: 2vh;
    margin-bottom: 2vh;
}

.garden-name {
    font-size: 2.5vh;
    font-weight: bold;
    color: rgb(12, 60, 38);

    margin-top: 2vh;
    margin-bottom: 2vh;
}

.garden-location {
    font-size: 2.5vh;
    font-weight: bold;
    color: rgb(99, 110, 115);

    margin-top: 2vh;
    margin-bottom: 2vh;
}

.discription {
    font-size: 2.5vh;
    font-weight: bold;
    color: rgb(12, 60, 38);
}
</style>

<script>
export default {
    name: 'VolunteerBlock',
    props: {
        content: {
            type: Object,
            required: true
        }
    },
}
</script>
