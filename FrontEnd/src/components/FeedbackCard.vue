<!-- 反馈模块，仅在FeedbackView里使用 -->

<template>
    <div class="card">
        <div class="card-body">

            <!-- 分隔线 -->
            <div class="colored-line"></div>

            <!-- 标题 -->
            <h1 class="heading">
                意见反馈
                <!-- 图标 -->
                <svg xmlns="http://www.w3.org/2000/svg" width="40" fill="currentColor" class="bi bi-card-checklist"
                    viewBox="0 0 16 16">
                    <path
                        d="M14.5 3a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-13a.5.5 0 0 1-.5-.5v-9a.5.5 0 0 1 .5-.5h13zm-13-1A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-13z" />
                    <path
                        d="M7 5.5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5zm-1.496-.854a.5.5 0 0 1 0 .708l-1.5 1.5a.5.5 0 0 1-.708 0l-.5-.5a.5.5 0 1 1 .708-.708l.146.147 1.146-1.147a.5.5 0 0 1 .708 0zM7 9.5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5zm-1.496-.854a.5.5 0 0 1 0 .708l-1.5 1.5a.5.5 0 0 1-.708 0l-.5-.5a.5.5 0 0 1 .708-.708l.146.147 1.146-1.147a.5.5 0 0 1 .708 0z" />
                </svg>
            </h1>

            <!-- 分隔线 -->
            <div class="colored-line"></div>

            <!-- 问题分类 -->
            <h5 class="subheading">
                <!-- 图标 -->
                <svg xmlns="http://www.w3.org/2000/svg" width="18" fill="currentColor" class="bi bi-1-square"
                    viewBox="0 0 16 16">
                    <path d="M9.283 4.002V12H7.971V5.338h-.065L6.072 6.656V5.385l1.899-1.383h1.312Z" />
                    <path
                        d="M0 2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V2Zm15 0a1 1 0 0 0-1-1H2a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V2Z" />
                </svg>
                问题分类
            </h5>
            <!-- 网格结构展示分类选项 -->
            <div class="row">
                <!-- 3种分类 -->
                <div class="col">
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="exampleRadios" id="登录与注册" value="登录与注册" checked>
                        <label class="form-check-label" for="登录与注册">&emsp;登录与注册</label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="exampleRadios" id="花园信息与功能" value="花园信息与功能">
                        <label class="form-check-label" for="花园信息与功能">&emsp;花园信息与功能</label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="exampleRadios" id="帖子与评论" value="帖子与评论">
                        <label class="form-check-label" for="帖子与评论">&emsp;帖子与评论</label>
                    </div>
                </div>
                <!-- 3种分类 -->
                <div class="col">
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="exampleRadios" id="活动与志愿者" value="活动与志愿者">
                        <label class="form-check-label" for="活动与志愿者">&emsp;活动与志愿者</label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="exampleRadios" id="安全与隐私" value="安全与隐私">
                        <label class="form-check-label" for="安全与隐私">&emsp;安全与隐私</label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="exampleRadios" id="其他问题和建议" value="其他问题和建议">
                        <label class="form-check-label" for="其他问题和建议">&emsp;其他问题和建议</label>
                    </div>
                </div>
            </div>

            <!-- 输入标题 -->
            <h5 class="subheading">
                <!-- 图标 -->
                <svg xmlns="http://www.w3.org/2000/svg" width="18" fill="currentColor" class="bi bi-2-square"
                    viewBox="0 0 16 16">
                    <path
                        d="M6.646 6.24v.07H5.375v-.064c0-1.213.879-2.402 2.637-2.402 1.582 0 2.613.949 2.613 2.215 0 1.002-.6 1.667-1.287 2.43l-.096.107-1.974 2.22v.077h3.498V12H5.422v-.832l2.97-3.293c.434-.475.903-1.008.903-1.705 0-.744-.557-1.236-1.313-1.236-.843 0-1.336.615-1.336 1.306Z" />
                    <path
                        d="M0 2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V2Zm15 0a1 1 0 0 0-1-1H2a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V2Z" />
                </svg>
                标题
            </h5>
            <!-- 标题输入区域 -->
            <div class="form-floating mb-3">
                <input type="txet" class="form-control" id="topic" placeholder="请填写标题">
                <label for="topic">请填写标题</label>
            </div>

            <!-- 输入内容 -->
            <h5 class="subheading">
                <!-- 图标 -->
                <svg xmlns="http://www.w3.org/2000/svg" width="18" fill="currentColor" class="bi bi-3-square"
                    viewBox="0 0 16 16">
                    <path
                        d="M7.918 8.414h-.879V7.342h.838c.78 0 1.348-.522 1.342-1.237 0-.709-.563-1.195-1.348-1.195-.79 0-1.312.498-1.348 1.055H5.275c.036-1.137.95-2.115 2.625-2.121 1.594-.012 2.608.885 2.637 2.062.023 1.137-.885 1.776-1.482 1.875v.07c.703.07 1.71.64 1.734 1.917.024 1.459-1.277 2.396-2.93 2.396-1.705 0-2.707-.967-2.754-2.144H6.33c.059.597.68 1.06 1.541 1.066.973.006 1.6-.563 1.588-1.354-.006-.779-.621-1.318-1.541-1.318Z" />
                    <path
                        d="M0 2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V2Zm15 0a1 1 0 0 0-1-1H2a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V2Z" />
                </svg>
                内容
            </h5>
            <!-- 内容输入区域 -->
            <div class="form-floating">
                <textarea class="form-control" placeholder="请填写具体内容" id="content" style="height: 20vh"></textarea>
                <label for="content">请填写具体内容</label>
            </div>

            <!-- 上传图片 -->
            <h5 class="subheading">
                <!-- 图标 -->
                <svg xmlns="http://www.w3.org/2000/svg" width="18" fill="currentColor" class="bi bi-4-square"
                    viewBox="0 0 16 16">
                    <path
                        d="M7.519 5.057c.22-.352.439-.703.657-1.055h1.933v5.332h1.008v1.107H10.11V12H8.85v-1.559H4.978V9.322c.77-1.427 1.656-2.847 2.542-4.265ZM6.225 9.281v.053H8.85V5.063h-.065c-.867 1.33-1.787 2.806-2.56 4.218Z" />
                    <path
                        d="M0 2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V2Zm15 0a1 1 0 0 0-1-1H2a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V2Z" />
                </svg>
                上传图片
            </h5>
            <!-- 图片上传区域 -->
            <input class="form-control" type="file" id="formFileMultiple" multiple accept="image/*">

            <div class="form-text"> 非必填项</div>

            <!-- 联系方式 -->
            <h5 class="subheading">
                <!-- 图标 -->
                <svg xmlns="http://www.w3.org/2000/svg" width="18" fill="currentColor" class="bi bi-5-square"
                    viewBox="0 0 16 16">
                    <path
                        d="M7.994 12.158c-1.57 0-2.654-.902-2.719-2.115h1.237c.14.72.832 1.031 1.529 1.031.791 0 1.57-.597 1.57-1.681 0-.967-.732-1.57-1.582-1.57-.767 0-1.242.45-1.435.808H5.445L5.791 4h4.705v1.103H6.875l-.193 2.343h.064c.17-.258.715-.68 1.611-.68 1.383 0 2.561.944 2.561 2.585 0 1.687-1.184 2.806-2.924 2.806Z" />
                    <path
                        d="M0 2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V2Zm15 0a1 1 0 0 0-1-1H2a1 1 0 0 0-1 1v12a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V2Z" />
                </svg>
                联系方式
            </h5>
            <!-- 邮箱填写区域 -->
            <div class="form-floating mb-3">
                <input type="email" class="form-control" id="email" placeholder="请填写邮箱地址以便回复">
                <label for="email">请填写邮箱地址以便回复</label>
            </div>

            <!-- 提交按钮 -->
            <button type="button" class="btn btn-success" @click="commit" data-bs-toggle="modal"
                data-bs-target="#Modal">提交</button>

            <!-- 模态框 -->
            <div class="modal fade" id="Modal" tabindex="-1" aria-labelledby="ModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <!-- 标题部分 -->
                        <div class="modal-header">
                            <h1 class="subheading" id="ModalLabel" style="font-weight: bold;">
                                提交信息
                                <!-- 图标 -->
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" fill="currentColor"
                                    class="bi bi-chat-left-text" viewBox="0 0 16 16">
                                    <path
                                        d="M14 1a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H4.414A2 2 0 0 0 3 11.586l-2 2V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12.793a.5.5 0 0 0 .854.353l2.853-2.853A1 1 0 0 1 4.414 12H14a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z" />
                                    <path
                                        d="M3 3.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zM3 6a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9A.5.5 0 0 1 3 6zm0 2.5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5z" />
                                </svg>
                            </h1>
                            <!-- 关闭按钮 -->
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <!-- 内容部分 -->
                        <div class="modal-body">
                            <p>感谢您的反馈！您的意见已成功提交。</p>
                            <p>我们非常重视您的意见，它将帮助我们不断改进和优化服务。</p>
                            <p>如有需要，我们将尽快与您联系。</p>
                            <p>再次感谢您的宝贵意见！</p>
                        </div>
                        <!-- 底部按钮 -->
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" data-bs-dismiss="modal">确认</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { postFeedback } from '../api/Feedback.js';

export default {
    name: "FeedbackCard",

    setup() {
        const commit = () => {
            // 获取用户选择的radio的值
            var radios = document.querySelectorAll('input[type="radio"]');
            var selectedRadio = '';
            radios.forEach(function (radio) {
                if (radio.checked) {
                    selectedRadio = radio.value;
                }
            });

            // 获取标题的值
            var topic = document.getElementById('topic').value;

            // 获取内容的值
            var content = document.getElementById('content').value;

            // 获取文件的值
            var files = document.getElementById('formFileMultiple').files;

            // 获取邮箱地址的值
            var email = document.getElementById('email').value;

            // 清空输入框的值
            document.getElementById('topic').value = '';
            document.getElementById('content').value = '';
            document.getElementById('formFileMultiple').value = '';
            document.getElementById('email').value = '';
            document.getElementById('登录与注册').checked = true;

            // 提交
            postFeedback("1", selectedRadio, topic, content, files, email);
        };

        return {
            commit,
        };
    }
}
</script>

<style scoped>
.card {
    width: 50vw;
    padding: 3vh;
    border-width: 0vh;
    border-radius: 5vh;
    box-shadow: 8px 8px 24px rgba(0, 0, 0, 0.2);
}

.colored-line {
    height: 1px;
    background-color: rgb(12, 60, 38);
    margin-top: 2vh;
    margin-bottom: 2vh;
}

.form-check {
    margin-top: 2vh;
    margin-bottom: 2vh;
}

.heading {
    text-align: center;
    font-size: 6vh;
    font-weight: bold;
    color: rgb(12, 60, 38);
    margin-top: 3vh;
    margin-bottom: 3vh;
}

.subheading {
    font-size: 3vh;
    color: rgb(12, 60, 38);
    margin-top: 2vh;
    margin-bottom: 2vh;
}

p {
    text-align: center;
    font-size: 2.3vh;
    color: rgb(12, 60, 38);
    margin-top: 2vh;
    margin-bottom: 2vh;
}

input[type="radio"]:checked+label {
    color: rgb(12, 60, 38);
    font-weight: bold;
    transform: scale(1.05);
    transition: 500ms;
}

.btn {
    margin-top: 3vh;
    margin-bottom: 3vh;
    width: 10vw;
}
</style>